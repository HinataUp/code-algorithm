// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

namespace test;

class Program {
    static void Main() {
        for (int j = 0; j < 3; j++) {
            for(int i = 0; i < 5; i++){
                if(i == 4){
                    break ;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("j = " + j);
        }
        
    }
}