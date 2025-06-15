// GameFramework.cs
using System;

namespace GameProject
{
    /// <summary>
    /// 遊戲框架類別，包含遊戲邏輯和介面定義
    /// </summary>
    public class GameFramework
    {
        /// <summary>
        /// 遊戲介面，定義基本遊戲操作
        /// </summary>
        public interface IGame
        {
            void Start();
            GameResult PlayRound();
            string GetResultText();
        }

        /// <summary>
        /// 玩家介面，定義玩家基本屬性
        /// </summary>
        public interface IPlayer
        {
            string Name { get; }
        }

        /// <summary>
        /// 玩家類別，實作玩家介面
        /// </summary>
        public class Player : IPlayer
        {
            public string Name { get; private set; }

            public Player(string name)
            {
                Name = name;
            }
        }

        /// <summary>
        /// 骰子遊戲邏輯類別
        /// </summary>
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

            /// <summary>
            /// 開始新遊戲，重置分數
            /// </summary>
            public void Start()
            {
                Player1Wins = 0;
                Player2Wins = 0;
            }

            /// <summary>
            /// 進行一回合遊戲
            /// </summary>
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

<<<<<<< HEAD
=======
            /// <summary>
            /// 玩家1擲骰子
            /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            public void RollPlayer1()
            {
                Player1Roll = random.Next(1, 7);
            }

<<<<<<< HEAD
=======
            /// <summary>
            /// 玩家2擲骰子
            /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            public void RollPlayer2()
            {
                Player2Roll = random.Next(1, 7);
                UpdateScore();
            }

<<<<<<< HEAD
=======
            /// <summary>
            /// 更新分數
            /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            private void UpdateScore()
            {
                if (Player1Roll > Player2Roll)
                    Player1Wins++;
                else if (Player2Roll > Player1Roll)
                    Player2Wins++;
                // 平手不計分
            }

<<<<<<< HEAD
=======
            /// <summary>
            /// 取得遊戲結果文字
            /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            public string GetResultText()
            {
                return $"{player1.Name} 丟出 {Player1Roll}, {player2.Name} 丟出 {Player2Roll}.";
            }

            /// <summary>
            /// 取得獲勝者文字
            /// </summary>
            public string GetWinnerText()
            {
                if (Player1Roll > Player2Roll) return $"{player1.Name} 贏了!";
                if (Player1Roll < Player2Roll) return $"{player2.Name} 贏了!";
                return "平手!";
            }

            /// <summary>
            /// 取得分數文字
            /// </summary>
            public string GetScoreText()
            {
                return $"{player1.Name}: {Player1Wins} 勝, {player2.Name}: {Player2Wins} 勝";
            }

            /// <summary>
            /// 檢查遊戲是否結束
            /// </summary>
            public bool IsGameOver()
            {
                return Player1Wins == 3 || Player2Wins == 3;
            }
        }

        /// <summary>
        /// 剪刀石頭布遊戲的選擇
        /// </summary>
        public enum RPSMove
        {
            Rock,
            Paper,
            Scissors
        }

        /// <summary>
        /// 剪刀石頭布遊戲邏輯類別
        /// </summary>
        public class RPSGameLogic : IGame
        {
            private Random random = new Random();
            private IPlayer player1;
            private IPlayer player2;
            private RPSMove player1Move;
            private RPSMove player2Move;
            
            public int Player1Wins { get; private set; } = 0;
            public int Player2Wins { get; private set; } = 0;

            public RPSGameLogic(IPlayer p1, IPlayer p2)
            {
                player1 = p1;
                player2 = p2;
            }

            /// <summary>
            /// 設定玩家選擇
            /// </summary>
            public void SetMoves(RPSMove move1, RPSMove move2)
            {
                player1Move = move1;
                player2Move = move2;
            }

            /// <summary>
            /// 設定電腦選擇
            /// </summary>
            public void SetCpuMoves()
            {
                player1Move = (RPSMove)random.Next(0, 3);
                player2Move = (RPSMove)random.Next(0, 3);
            }

            /// <summary>
            /// 開始新遊戲，重置分數
            /// </summary>
            public void Start()
            {
                Player1Wins = 0;
                Player2Wins = 0;
            }

            /// <summary>
            /// 檢查遊戲是否結束
            /// </summary>
            public bool IsGameOver()
            {
                return Player1Wins == 3 || Player2Wins == 3;
            }

            /// <summary>
            /// 進行一回合遊戲
            /// </summary>
            public GameResult PlayRound()
            {
                if (player1Move == player2Move)
                    return GameResult.Draw;

                if ((player1Move == RPSMove.Rock && player2Move == RPSMove.Scissors) ||
                    (player1Move == RPSMove.Paper && player2Move == RPSMove.Rock) ||
                    (player1Move == RPSMove.Scissors && player2Move == RPSMove.Paper))
                {
                    Player1Wins++;
                    return GameResult.Win;
                }
                else
                {
                    Player2Wins++;
                    return GameResult.Lose;
                }
            }

            /// <summary>
            /// 取得分數文字
            /// </summary>
            public string GetScoreText()
            {
                return $"{player1.Name}: {Player1Wins} 勝, {player2.Name}: {Player2Wins} 勝";
            }

            /// <summary>
            /// 取得遊戲結果文字
            /// </summary>
            public string GetResultText()
            {
                return $"{player1.Name} 出 {player1Move}, {player2.Name} 出 {player2Move}.";
            }

<<<<<<< HEAD
=======
            /// <summary>
            /// 取得獲勝者文字
            /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            public string GetWinnerText()
            {
                if (player1Move == player2Move)
                    return "平手!";
                if ((player1Move == RPSMove.Rock && player2Move == RPSMove.Scissors) ||
                    (player1Move == RPSMove.Paper && player2Move == RPSMove.Rock) ||
                    (player1Move == RPSMove.Scissors && player2Move == RPSMove.Paper))
                {
                    return $"{player1.Name} 贏了!";
                }
                else
                {
                    return $"{player2.Name} 贏了!";
                }
            }
        }

        /// <summary>
        /// 遊戲結果列舉
        /// </summary>
        public enum GameResult
        {
            Win,
            Lose,
            Draw
        }
    }
}
