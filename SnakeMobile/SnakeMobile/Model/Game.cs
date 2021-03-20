using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SnakeMobile.Helpers;

namespace SnakeMobile.Model
{
    public class Game : INotifyPropertyChanged
    {
        private AudioHelper audioHelper;
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
        private DateTime endTime;
        public TimeSpan Duration
        {
            get => endTime - startTime;
        }

        public Game()
        {
            GameBoard = new GameBoard();
        }

        public async Task StartGameLoop()
        {
            startTime = DateTime.UtcNow;

            do
            {
                await GameBoard.MoveSnake();

                Score = GameBoard.Snake.CountPelletsConsumed;

                System.Threading.Thread.Sleep(200);
            } while (!GameBoard.IsInIllegalState);

            endTime = DateTime.UtcNow;
            AudioHelper.PlayGameOverSound();
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("SnakeMobile." + filename);

            return stream;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
