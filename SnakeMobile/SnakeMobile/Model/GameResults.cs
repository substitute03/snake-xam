using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeMobile.Model
{
    public class GameResults
    {
        public int Score { get; }
        public TimeSpan Duration { get; }

        public GameResults(int score, TimeSpan duration)
        {
            Score = score;
            Duration = duration;
        }
    }
}
