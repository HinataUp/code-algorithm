// See https://aka.ms/new-console-template for more information

using System.Text;

namespace code;

class Test {
    public int a = 1;
    public Test2 b = new Test2();

    // 保护类型 包裹一下
    public Test Clone() {
        // return (test)base.MemberwiseClone();
        return MemberwiseClone() as Test;
    }
}

class Test2 {
    public int a2 = 2;
}

internal static class My {
    public static void Main() {
        StringBuilder sb = new StringBuilder("hello world");
        sb.AppendFormat(" {0}{1}","hello","world");
        
        Console.WriteLine(sb.ToString());
        return;
    }
}
