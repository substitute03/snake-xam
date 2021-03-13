using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeMobile.ViewModels
{
    public class MainMenuViewModel
    {
        public List<String> Difficulties
        {
            get => new List<string>
            {
                "Normal", "Hard", "Insanity"
            };
        }
    }
}
