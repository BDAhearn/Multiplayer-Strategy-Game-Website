async function createLobby() {
    const gameId = document.getElementById("gameSelect").value;
    const visibility = document.getElementById("visibility").value;
    const token = localStorage.getItem("token");

    const response = await fetch("https://localhost:7168/api/lobby", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify({
            lobbyGameId: parseInt(gameId),
            lobbyVisibility: visibility
        })
    });

    const data = await response.json();
    console.log(data);

    if (response.ok) {
        localStorage.setItem("LobbyID", data.lobbyId);
        localStorage.setItem("playerRole", data.role);

        window.location.href = `play.html?lobbyId=${data.lobbyId}`;
    } else {
        document.getElementById("result").innerText =
            "Error creating lobby";
    }
}

async function loadGamesList() {
    const dropdown = document.getElementById("gameSelect");

    if (!dropdown) {
        console.error("gameSelect not found");
        return;
    }

    const response = await fetch("https://localhost:7168/api/game/available");
    const games = await response.json();

    dropdown.innerHTML = "";

    games.forEach(game => {
        const option = document.createElement("option");

        let label = game.gameName;

        if (game.gameStatus === "Testing") {
            label += " - testing";
        }

        if (game.gameStatus === "Closed") {
            option.disabled = true;
            label += " - closed";
        }

        option.value = game.gameId;
        option.text = label;

        dropdown.appendChild(option);
    });
}

async function loadLobbies() {
    const response = await fetch("https://localhost:7168/api/lobby");
    const lobbies = await response.json();

    const tbody = document.getElementById("lobbyTableBody");
    tbody.innerHTML = "";

    lobbies.forEach(lobby => {
        const row = document.createElement("tr");

        row.innerHTML = `
            <td>${lobby.lobbyId}</td>
            <td>${lobby.gameName}</td>
            <td>${lobby.hostName}</td>
            <td>${lobby.challengerName ?? "-"}</td>
            <td>${lobby.lobbyStatus}</td>
            <td>${new Date(lobby.lobbyDateCreated).toLocaleString()}</td>
            <td>${lobby.lobbyVisibility}</td>
            <td>
                ${lobby.lobbyStatus === "Open"
                ? `<button onclick="joinLobby(${lobby.lobbyId})">Join</button>`
                : `<button onclick="enterLobby(${lobby.lobbyId})">View</button>`
            }
            </td>
        `;

        tbody.appendChild(row);
    });
}

async function joinLobby(lobbyId) {
    const token = localStorage.getItem("token");

    const response = await fetch(
        `https://localhost:7168/api/lobby/${lobbyId}/join`,
        {
            method: "POST",
            headers: {
                "Authorization": `Bearer ${token}`
            }
        }
    );
    const data = await response.json();

    if (response.ok) {
        localStorage.setItem("LobbyID", data.lobbyId);
        localStorage.setItem("playerRole", data.role);

        window.location.href = `play.html?lobbyId=${data.lobbyId}`;
    } else {
        alert("Failed to join lobby");
    }
}

function enterLobby(lobbyId) {
    localStorage.setItem("LobbyID", lobbyId);
    localStorage.setItem("Role", )
    window.location.replace("play.html");
}