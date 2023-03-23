// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

namespace test;

class Program {
    public static void Main() {
        p kiki = new p("kiki", 11, null) {
        };
        p mac = new p("mac", 10, kiki) {
        };
        mac.name = "mac";
        Console.WriteLine(mac.friend.name + mac.friend.age);
        return;
    }
}

class p {
    public string name;
    public int age;
    public p friend;

    public string Name {
        get;
        set;
    }

    public p(string name, int age, p friend) {
        this.name = name;
        this.age = age;
        this.friend = friend;
    }

    ~p() {
        Console.WriteLine("bye");
    }
}