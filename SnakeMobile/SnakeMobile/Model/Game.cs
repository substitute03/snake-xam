using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMobile.Model
{
    public class Game : INotifyPropertyChanged
    {
        public GameBoard GameBoard { get; set; }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                RaisePropertyChanged(nameof(Score));
            }
        }

        private DateTime startTime;
        private DateTime currentTime;
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                _duration = currentTime - startTime;

                TimeSpan span = currentTime - startTime;
            }
        }

        public Game()
        {
            GameBoard = new GameBoard();
        }

        public async Task StartGameLoop()
        {
            do
            {
                await GameBoard.MoveSnake();
                Score = GameBoard.Snake.CountPelletsConsumed;

                System.Threading.Thread.Sleep(200);

            } while (!GameBoard.IsInIllegalState);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
