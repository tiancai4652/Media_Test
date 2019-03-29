using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest
{
    //WhereT练习
    //https://www.cnblogs.com/a164266729/p/5301541.html
    //https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    public class WhrereT
    {
    }

    //定义
    //where T : struct | T必须是一个结构类型
    //where T : class T必须是一个类（class）类型
    //where T : new() | T必须要有一个无参构造函数
    //where T : NameOfBaseClass | T必须继承名为NameOfBaseClass的类
    //where T : NameOfInterface | T必须实现名为NameOfInterface的接口

    class MyClass<T, U>
    where T : class
    where U : struct
    { }
}
