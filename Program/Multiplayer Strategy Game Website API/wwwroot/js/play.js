let connection;
let lobbyId;
let playerRole;

window.addEventListener("DOMContentLoaded", async () => {

    lobbyId = new URLSearchParams(window.location.search).get("lobbyId")
        || localStorage.getItem("LobbyID");

    playerRole = localStorage.getItem("playerRole");

    await startSignalR();
    await loadLobby();
    await loadHeader();
});

async function startSignalR() {

    connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7168/play")
        .withAutomaticReconnect()
        .build();

    connection.on("PlayerJoined", (user) => {
        const el = document.getElementById("challengerName");
        if (el) {
            el.innerText = "Challenger: " + user;
        }
    });

    try {
        await connection.start();

        const token = localStorage.getItem("token");
        let username = "Unknown";

        if (token) {
            const payload = parseJwt(token);
            username = payload?.Name || payload?.name || payload?.sub || "Unknown";
        }

        if (!lobbyId) {
            lobbyId = localStorage.getItem("LobbyID");
        }

        await connection.invoke("JoinLobby", lobbyId, username);

    } catch (err) {
        console.error("SignalR connection failed:", err);
    }
}

async function loadLobby() {
    const response = await fetch("https://localhost:7168/api/lobby");
    const lobbies = await response.json();

    const lobby = lobbies.find(l => l.lobbyId == lobbyId);

    if (!lobby) {
        alert("Lobby not found");
        return;
    }

    lobbyData = lobby;

    document.getElementById("hostName").innerText =
        "Host: " + lobby.hostName;

    document.getElementById("challengerName").innerText =
        "Challenger: " + (lobby.challengerName || "Waiting...");

    document.getElementById("gameTitle").innerText =
        lobby.gameName;

    playerRole = localStorage.getItem("playerRole") || "spectator";

    await loadGame(lobby.gameName);
}

async function loadGame(gameName) {
    const container = document.getElementById("gameContainer");

    let htmlFile = "";
    let scriptFile = "";

    if (gameName === "TicTacToe") {
        htmlFile = "games/tictactoe.html";
        scriptFile = "js/games/tictactoe.js";
    }

    if (!htmlFile) {
        container.innerText = "Game not found";
        return;
    }

    const html = await fetch(htmlFile).then(r => r.text());
    container.innerHTML = html;

    await new Promise(r => setTimeout(r, 0));

    const script = document.createElement("script");
    script.src = scriptFile;
    document.body.appendChild(script);

    script.onload = () => {
        if (window.onGameInit) {
            window.onGameInit({
                connection,
                lobbyId,
                playerRole
            });
        }
    };
}