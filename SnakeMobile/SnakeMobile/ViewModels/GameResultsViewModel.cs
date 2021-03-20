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
        public GameResultsViewModel(int finalScore, TimeSpan gameDuration)
        {
            FinalScore = finalScore;
            GameDuration = gameDuration;
        }
    }
}
