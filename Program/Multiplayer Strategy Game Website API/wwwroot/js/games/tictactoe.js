let gameConnection = null;
let playerSymbol = null;
let currentTurn = "X";


window.onGameInit = async function (ctx) {
    lobbyId = ctx.lobbyId;
    playerSymbol = ctx.playerRole === "host" ? "X" : "O";

    await setupSignalR();
    await setupBoard();
};


async function setupSignalR() {
    gameConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7168/tictactoe")
        .withAutomaticReconnect()
        .build();

    gameConnection.off("GameUpdated");

    gameConnection.on("GameUpdated", (state) => {
        renderBoard(state.board);

        currentTurn = state.currentTurn;
        window.currentTurn = currentTurn;
        console.log("GameUpdated:", state);

        if (state.winner != null) {
            document.getElementById("winner").innerHTML = "The winner is: " + state.winner + "!";
            currentTurn = null;
        }
    });

    await gameConnection.start();

    console.log("TicTacToe connected");
    await gameConnection.invoke("JoinLobby", lobbyId);
}

function setupBoard() {
    const cells = document.querySelectorAll(".cell");

    if (!cells.length) {
        console.error("TicTacToe board not found");
        return;
    }

    cells.forEach(cell => {
        cell.onclick = () => {
            const index = parseInt(cell.id);

            if (!currentTurn) return; 
            if (cell.innerText !== "") return;
            if (currentTurn !== playerSymbol) return;
            console.log("clicked");
            try {
                gameConnection.invoke("MakeMove", lobbyId, index);
                console.log(lobbyId);
                console.log(index);
            } catch (err) {
                console.error("Move failed:", err);
            }
        };
    });
}

function renderBoard(board) {
    if (!board || board.length !== 9) {
        console.warn("Invalid board received:", board);
        return;
    }

    board.forEach((value, index) => {
        const cell = document.getElementById(index.toString());
        if (cell) {
            cell.innerText = value || "";
        }
    });
}