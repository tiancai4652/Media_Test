using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Generic
{
    interface IWindowHelper
    {
        void ShowWindow(object dataContext = null);
        void ShowWindowModal(object dataContext = null);
    }
}
