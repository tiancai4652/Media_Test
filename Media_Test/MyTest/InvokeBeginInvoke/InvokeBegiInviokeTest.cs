using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.InvokeBeginInvoke
{
    //Incoke和BeginInvoke原理及使用
    //https://www.cnblogs.com/zhangchenliang/p/4953649.html

    //使用Invoke完成一个委托方法的封送，就类似于使用SendMessage方法来给界面线程发送消息，是一个同步方法。
    //也就是说在Invoke封送的方法被执行完毕前，Invoke方法不会返回，从而调用者线程将被阻塞。

    //使用BeginInvoke方法封送一个委托方法，类似于使用PostMessage进行通信，这是一个异步方法。
    //也就是该方法封送完毕后马上返回，不会等待委托方法的执行结束，调用者线程将不会被阻塞。
    //但是调用者也可以使用EndInvoke方法或者其它类似WaitHandle机制等待异步操作的完成。

    //但是在内部实现上，Invoke和BeginInvoke都是用了PostMessage方法，从而避免了SendMessage带来的问题。
    //而Invoke方法的同步阻塞是靠WaitHandle机制来完成的。

    //SendMessage是windows api，用来把一个消息发送到一个窗口的消息队列。这个方法是个阻塞方法，也就是操作系统会确保消息的确发送到目的消息队列，并且该消息被处理完毕以后，该函数才返回。返回之前，调用者将会被暂时阻塞。
    //PostMessage也是一个用来发送消息到窗口消息队列的api函数，但这个方法是非阻塞的。也就是它会马上返回，而不管消息是否真的发送到目的地，也就是调用者不会被阻塞。

    //*ISynchronizeInvoke有一个属性，InvokeRequired。这个属性就是用来在编程的时候确定，一个对象访问UI控件的时候是否需要使用Invoke或者BeginInvoke来进行封送
    public class InvokeBegiInviokeTest
    {
        //Point1 :用InvokeRequired来判断当前是否和UI线程处在同一线程，即是否需要调用Invoke或BeginInvoke
        //Point2 :Invoke相当于同步执行其方法，调用者发送个消息到主线程消息队列，并等待期完成会阻塞主线程继续执行下一条消息.
        //Point3 :BeginInvoke相当于异步，调用者发送消息后立即返回，不等待其执行完毕
        //Point4 :调用者是去找控件的主窗体，是在UI线程里，所以用Invoke会阻塞（调用者等待-->主窗体等待）
    }
}
