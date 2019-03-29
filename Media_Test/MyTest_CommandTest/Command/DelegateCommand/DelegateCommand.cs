using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTest_CommandTest.Command.DelegateCommand
{
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// 当（可执行->不可执行/不可执行->可执行）时发生的事件
        /// https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.input.icommand.canexecutechanged?redirectedfrom=MSDN&view=netframework-4.7.2
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 是否执行缓存(用来对比【可执行】是否改变）
        /// </summary>
        bool canExecuteCache;

        /// <summary>
        /// 判断当前命令是否可以执行
        /// https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.input.icommand.canexecute?view=netframework-4.7.2
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            bool temp = canExecute(parameter);
            if (canExecuteCache != temp)
            {
                canExecuteCache = temp;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }
            return canExecuteCache;
        }

        /// <summary>
        /// （当前命令可执行时）执行的命令
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executeAction(parameter);
        }

        Func<object, bool> canExecute;
        Action<object> executeAction;
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

      

    }
}
