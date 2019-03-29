using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace MediaPlayer.Generic
{
    public class WindwosHelper<T> : IWindowHelper where T: Window, new()
    {
        public void ShowWindow(object dataContext = null)
        {
            Window window = new T();
            if (dataContext!= null)
            {
                window.DataContext = dataContext;
            }
            window.Show();
        }

        public void ShowWindowModal(object dataContext = null)
        {
            Window window = new T();
            if (dataContext != null)
            {
                window.DataContext = dataContext;
            }
            window.ShowDialog();
        }
    }
}
