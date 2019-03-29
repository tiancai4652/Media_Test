using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Generic
{
    public static class Mediator<T>
    {
        private static IDictionary<T, Action<object>> _dir = new Dictionary<T, Action<object>>();

        public static void Register(T message, Action<object>act)
        {
            if (!_dir.Keys.Contains(message))
            {
                _dir.Add(message, act);
            }
        }

        public static void UnRegister(T message)
        {
            if (_dir.Keys.Contains(message))
            {
                _dir.Remove(message);
            }
        }

        public static void CallAction(T message,object args)
        {
            if (_dir.Keys.Contains(message))
            {
                _dir[message](args);
            }
        }
    }
}
