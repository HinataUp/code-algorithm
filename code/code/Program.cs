using System.Reflection;

namespace code;

class My {
    public static void Main() {
        // 获取type
        // 1. object.GetType() 获取对象的Type (万物之父，因此任何类型都有这个方法)
        int a = 0;
        Type t1 = a.GetType();
        Console.WriteLine(t1);

        // 2. 通过typeof关键字传入类名，也可以得到对象的Type
        Type t2 = typeof(int);
        Console.WriteLine(t2);

        // 3. 通过类的名字也可以获取类型，注意类名必须包含 命名空间，不然找不到
        Type t3 = Type.GetType("System.Int32");
        Console.WriteLine(t3);
        // 实际上 t1 t2 t2 的堆内存是同一个（即使在栈中变量名不同）

        // 获取类的程序集信息,用得少
        Console.WriteLine(t1.Assembly);

        // 获取类中的所有公共成员
        Type test = typeof(Test);
        MemberInfo[] members = test.GetMembers();
        for (int i = 0; i < members.Length; i++) {
            Console.WriteLine(members[i]);
        }

        // 获取类的所有构造函数并调用
        ConstructorInfo[] constructors = test.GetConstructors();
        for (int i = 0; i < constructors.Length; i++) {
            Console.WriteLine(constructors[i]);
        }

        // 得到构造函数需要传入type 数组， 数组内容按顺序是参数类型，没有参数就new Type[0]
        // 执行构造函数需要传入object 数组， 表示按照顺序传入参数
        // 1. 得到无参构造函数
        ConstructorInfo info = test.GetConstructor(new Type[0]);
        Test obj = info.Invoke(null) as Test; // 执行可以传参，无参构造传null即可
        Console.WriteLine(obj.j);
        // 2. 得到有参构造函数, 获得一个参数为int的构造函数，然后传入int 参数值为2 ，注意原先i 是1 
        ConstructorInfo info2 = test.GetConstructor(new Type[] { typeof(int) });
        obj = info2.Invoke(new object[] { 2 }) as Test; // 此时i就是2
        Console.WriteLine(obj.str);
        // 3. 得到多个参数的构造函数
        ConstructorInfo info3 = test.GetConstructor(new Type[] { typeof(int), typeof(string) });
        obj = info3.Invoke(new object[] { 3, "world" }) as Test; // 此时i就是3，str就是world
        // Console.WriteLine(obj.i); // i 是私有的 无法点出来 ，但是 i的值是3 确实被更改了
        Console.WriteLine(obj.str); // world，

        // 获取类中的 公共成员变量
        // 1. 获取所有公共成员变量
        FieldInfo[] fields = test.GetFields();
        for (int i = 0; i < fields.Length; i++) {
            Console.WriteLine(fields[i]);
        }

        // 2.得到指定 名称的公共成员变量 "务必先获取到成员反射信息"
        FieldInfo field = test.GetField("str"); // 传入的 string 类型 变量名
        Console.WriteLine(field); // 输出：System.String code.Test.str， 此时仅仅是获得 
        // 3. 通过反射获取和设置变量的值
        Test obj2 = new Test();
        obj2.j = 10;
        obj2.str = "obj2 test";
        Console.WriteLine(field.GetValue(obj2)); // obj2 test
        // 4. 通过反射设置变量的值
        field.SetValue(obj2, "obj2 change str"); // 设置变量的值
        Console.WriteLine(field.GetValue(obj2)); // obj2 change str
        // PS 由于field.GetValue 传入的是字符串，因此 输出时也是对应的字符串 而不是j 这个int

        // 获取类中的 公共方法 
        Type t = typeof(string); // 这里假定知道 类型名string
        MethodInfo[] methods = t.GetMethods();
        for (int i = 0; i < methods.Length; i++) {
            Console.WriteLine(methods[i]);
        }

        // 得到 substring 方法
        MethodInfo subStr = t.GetMethod("Substring",
            new Type[] { typeof(int), typeof(int) });
        // 如果静态方法，invoke 第一个参数传 null，
        // 如果是实例方法，invoke 第一个参数传入实例对象
        string s = "fanshe test";
        object res = subStr.Invoke(s, new object[] { 2, 5 }); // 第一册参数相当于 是哪个对象要执行这个成员方法
        Console.WriteLine(res); // nshe


        // Activator， 在System命名空间 
        // 1. 通过Type对象实例化对象
        Type test2 = typeof(Test);

        // 2. 通过Activator实例化对象, 无参构造函数
        Test obj5 = Activator.CreateInstance(test2) as Test;
        Console.WriteLine(obj5.str);
        // 3.  有参构造函数，次数利用变长构造函数参数， 参数填对即可操作
        Test obj6 = Activator.CreateInstance(test2, new object[] { 5, "obj6 test" }) as Test;
        Console.WriteLine(obj6.str);
        Console.WriteLine(obj6.j);
        // 乱填是直接跳过，因此这种方式要求参数填对
        
        
        // 程序集 Assembly
        // 1. 获取当前程序集 .dll  的文件名
        Assembly assembly = Assembly.LoadFrom(@"F:\code\code-algorithm\code\code\bin\Debug\net7.0\code");
        Type[] types = assembly.GetTypes();
        Console.WriteLine("当前程序集中的所有类型：");
        for (int i = 0; i < types.Length; i++) {
            Console.WriteLine(types[i]);
        }
        // 加载程序集中的一个类对象 之后才能使用反射
        Type tAss = assembly.GetType("code.Test");
        MemberInfo[] memberInfos = tAss.GetMembers();
        // 2. 获取当前程序集中的所有成员
        Console.WriteLine("当前程序集中的所有成员信息：");
        for (int i = 0; i < memberInfos .Length; i++) {
            Console.WriteLine(memberInfos[i]);
        }
        // 实例化对象
        Type tAss2 = assembly.GetType("code.Test");
        MemberInfo[] memberInfos2 = tAss2.GetMembers();
        for (int i = 0; i < memberInfos2.Length; i++) {
            Console.WriteLine(memberInfos2[i]);
        }
        // 获得我们不知道的type名的type 然后将他作为参数传入
        Type tAss3 = assembly.GetType("code.Test");
        return;
    }
}

class Test {
    private int i = 1;
    public int j = 0;
    public string str = "hello";

    public Test() {
    }

    public Test(int i) {
        this.i = i;
    }

    // 顺带把带参数 Test 构造函数一并执行了（先执行），然后再执行Test双参数构造函数
    public Test(int j, string str) : this(j) {
        this.j = j;
        this.str = str;
    }

    public void Speak() {
        Console.WriteLine("test speak");
    }
}