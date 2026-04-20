async function register() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    //needs to be updated so it doesn't send unencrypted password
    const result = await post("/register", {
        playerName: username,
        playerPasswordHash: password
    });

    alert("Account created!");
    window.location.href = "login.html";
}