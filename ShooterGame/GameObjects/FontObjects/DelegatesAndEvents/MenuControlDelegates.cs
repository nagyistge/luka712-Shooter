using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.FontObjects.DelegatesAndEvents
{
    /// <summary>
    /// Menu control event args.
    /// </summary>
    public class MenuControlEventArgs : EventArgs
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public MenuControlEventArgs(string selectionInfo)
        {
            MenuSelectionInfo = selectionInfo;
        }

        /// <summary>
        /// Gets selection info.
        /// </summary>
        public string MenuSelectionInfo { get; private set; }
    }

    /// <summary>
    /// OnMenuSelection delgate
    /// </summary>
    public delegate void OnMenuSelection(object sender, MenuControlEventArgs args);
}
