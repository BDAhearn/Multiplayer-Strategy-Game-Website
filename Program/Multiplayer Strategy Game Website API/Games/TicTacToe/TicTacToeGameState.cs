namespace Multiplayer_Strategy_Game_Website_API.Games.TicTacToe
{
    public class TicTacToeGameState
    {
        public string[] Board { get; set; } = new string[9];
        public string CurrentTurn { get; set; } = "X";
        public string Winner { get; set; } = null;
        public bool IsGameOver => Winner != null;

        public TicTacToeGameState()
        {
            for (int i = 0; i < 9; i++)
                Board[i] = "";
        }
    }
}