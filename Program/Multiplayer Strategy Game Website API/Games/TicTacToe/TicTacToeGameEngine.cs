namespace Multiplayer_Strategy_Game_Website_API.Games.TicTacToe
{
    public class TicTacToeEngine
    {
        public string[] BuildBoard(List<string> moves)
        {
            var board = new string[9];

            for (int i = 0; i < board.Length; i++)
                board[i] = "";

            for (int i = 0; i < moves.Count; i++)
            {
                int index = int.Parse(moves[i]);
                string symbol = i % 2 == 0 ? "X" : "O";

                board[index] = symbol;
            }

            return board;
        }

        public bool IsValidMove(List<string> moves, int index)
        {
            if (index < 0 || index > 8)
                return false;

            return !moves.Contains(index.ToString());
        }

        public string GetCurrentTurn(List<string> moves)
        {
            return moves.Count % 2 == 0 ? "X" : "O";
        }

        public string CheckWinner(string[] _board)
        {
            int[][] wins = new int[][]
            {
                new[] {0,1,2},
                new[] {3,4,5},
                new[] {6,7,8},
                new[] {0,3,6},
                new[] {1,4,7},
                new[] {2,5,8},
                new[] {0,4,8},
                new[] {2,4,6}
            };

            foreach (var w in wins)
            {
                if (!string.IsNullOrEmpty(_board[w[0]]) &&
                    _board[w[0]] == _board[w[1]] &&
                    _board[w[0]] == _board[w[2]])
                {
                    return _board[w[0]];
                }
            }

            if (CheckDraw(_board))
            {
                return "Draw";
            }

            return null;
        }

        static bool CheckDraw(string[] board)
        {
            return board.All(cell => !string.IsNullOrEmpty(cell));
        }
    }
}