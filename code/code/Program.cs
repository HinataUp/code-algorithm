// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;

namespace code;

internal static class My {
    public static void Main() {
        MyOther<MyClass,IMyInterface> myOther = new MyOther<MyClass,IMyInterface>();
        return;
    }
}
class MyOther<T,U> where T : U {
    public T value;
    public void MyTest<K,V>(K k) where K : V {
        // do something
    }
} 
// 接口
interface IMyInterface {
    void MyMethod();
}
// 实现
class MyClass : IMyInterface {
    public void MyMethod() {
        // do something
    }
}