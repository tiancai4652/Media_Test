using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Action
{
    //关于方法变量的练习Action/Func
    // https://blog.csdn.net/wf824284257/article/details/83661843
    //Action和Func两者的区别在于Action没有返回值，而Func有返回值。
    //都可以用Lamada表示
    //Func<int, bool> func = (t) => t >= 5;
    //System.Action EndMethod = () =>{ Console.WriteLine("ShowEnd");};
    // Predicate有且只有一个参数，返回值固定为bool

    public class ActionFunTest
    {
        static int num = 0;
        //原始
        public void OriFun()
        {
            while (num < 5)
            {
                num += 1;
                Console.WriteLine("show");
            }
            Console.WriteLine("ShowEnd");
        }

        //分析
        //不终止条件（num<5）。或者说终止条件(num>=5)
        //循环事件（num+=1;Console.WriteLine(“show”);）
        //终止后事件(Console.WriteLine(“ShowEnd”)😉

        public void NewFun(Func<int, bool> func, System.Action Method, System.Action EndMethod)
        {
            while (!func(num))
            {
                Method();
            }
            EndMethod();
            //对比？？
            //while (!func.Invoke(num))
            //{
            //    Method.Invoke();
            //}
            //EndMethod.Invoke();
        }

        public void NewFunWithLamada()
        {
            Func<int, bool> func = (t) => t >= 5;

            System.Action Method = () =>
              {
                  num += 1;
                  Console.WriteLine("show");
              };

            System.Action EndMethod = () =>
            {
                Console.WriteLine("ShowEnd");
            };

            while (!func(num))
            {
                Method();
            }
            EndMethod();
        }
    }
}
