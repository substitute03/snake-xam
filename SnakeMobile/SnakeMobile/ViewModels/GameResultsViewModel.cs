using SnakeMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeMobile.ViewModels
{
    public class GameResultsViewModel
    {
        public int FinalScore { get; private set; }
        public TimeSpan GameDuration { get; private set; }

        public GameResultsViewModel() { }
        public GameResultsViewModel(GameResults results)
        {
            FinalScore = results.Score;
            GameDuration = results.Duration;
        }
    }
}
