// See https://aka.ms/new-console-template for more information

namespace test;

class Program {
    // 定义一个委托，用于处理字符串
    delegate string StringHandler(string str);

    static void Main() {
        string[] arr = { "hello", "world", "csharp" };

        // 创建一个委托实例，指向ToUpper方法
        StringHandler handler = new StringHandler(str => str.ToUpper());

        // 使用委托处理字符串数组
        foreach (string str in arr) {
            string result = handler(str);
            Console.WriteLine(result);
        }
    }
}