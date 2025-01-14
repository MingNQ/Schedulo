using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Schedulo.Common
{
    internal class WindowManger
    {
        public Window Window { get; set; }

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="dialog"></param>
        public void ShowDialog(Window dialog)
        {
            if (Window != null)
            {
                dialog.Owner = Window;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            dialog.ShowDialog();
        }

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="dialog"></param>
        public void Show(Window dialog) 
        {
            if (Window != null)
            {
                dialog.Owner = Window;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            dialog.Show();
        }
    }
}
