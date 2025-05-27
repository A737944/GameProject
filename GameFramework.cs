// GameFramework.cs
using System;

namespace GameProject
{
    public class GameFramework
    {
        public interface IGame
        {
            void Start();
            GameResult PlayRound();
            string GetResultText();
        }

        public interface IPlayer
        {
            string Name { get; }
        }

        public class Player : IPlayer
        {
            public string Name { get; private set; }

            public Player(string name)
            {
                Name = name;
            }
        }

        public class DiceGameLogic : IGame
        {
            private Random random = new Random();
            private IPlayer player1;
            private IPlayer player2;

            public int Player1Roll { get; private set; }
            public int Player2Roll { get; private set; }

            public int Player1Wins { get; private set; }
            public int Player2Wins { get; private set; }

            public DiceGameLogic(IPlayer p1, IPlayer p2)
            {
                player1 = p1;
                player2 = p2;
            }

            public void Start()
            {
                Player1Wins = 0;
                Player2Wins = 0;
            }

            public GameResult PlayRound()
            {
                Player1Roll = random.Next(1, 7);
                Player2Roll = random.Next(1, 7);

                if (Player1Roll > Player2Roll)
                {
                    Player1Wins++;
                    return GameResult.Win;
                }
                else if (Player1Roll < Player2Roll)
                {
                    Player2Wins++;
                    return GameResult.Lose;
                }
                else
                {
                    return GameResult.Draw;
                }
            }

            public string GetResultText()
            {
                return $"{player1.Name} 丟出 {Player1Roll}, {player2.Name} 丟出 {Player2Roll}.";
            }

            public string GetWinnerText()
            {
                if (Player1Roll > Player2Roll) return $"{player1.Name} 贏了!";
                if (Player1Roll < Player2Roll) return $"{player2.Name} 贏了!";
                return "平手!";
            }

            public string GetScoreText()
            {
                return $"{player1.Name}: {Player1Wins} 勝, {player2.Name}: {Player2Wins} 勝";
            }

            public bool IsGameOver()
            {
                return Player1Wins == 3 || Player2Wins == 3;
            }
        }

        public enum RPSMove
        {
            Rock,
            Paper,
            Scissors
        }

        public class RPSGameLogic : IGame
        {
            private Random random = new Random();
            private IPlayer player1;
            private IPlayer player2;
            private RPSMove player1Move;
            private RPSMove player2Move;

            public RPSGameLogic(IPlayer p1, IPlayer p2)
            {
                player1 = p1;
                player2 = p2;
            }

            public void SetMoves(RPSMove move1, RPSMove move2)
            {
                player1Move = move1;
                player2Move = move2;
            }

            public void SetCpuMoves()
            {
                player1Move = (RPSMove)random.Next(0, 3);
                player2Move = (RPSMove)random.Next(0, 3);
            }

            public void Start() { }

            public GameResult PlayRound()
            {
                if (player1Move == player2Move) return GameResult.Draw;
                if ((player1Move == RPSMove.Rock && player2Move == RPSMove.Scissors) ||
                    (player1Move == RPSMove.Paper && player2Move == RPSMove.Rock) ||
                    (player1Move == RPSMove.Scissors && player2Move == RPSMove.Paper))
                    return GameResult.Win;

                return GameResult.Lose;
            }

            public string GetResultText()
            {
                return $"{player1.Name} 出 {player1Move}, {player2.Name} 出 {player2Move}.";
            }
        }

        public enum GameResult
        {
            Win,
            Lose,
            Draw
        }
    }
}
