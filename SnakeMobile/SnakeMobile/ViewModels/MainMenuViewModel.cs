using SnakeMobile.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SnakeMobile.ViewModels
{
    public class MainMenuViewModel
    {
        public string[] ControlsSchemes 
        {
            get
            {
                return Enum.GetNames(typeof(ControlScheme));
            }
        }
    }
}
