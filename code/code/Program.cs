// See https://aka.ms/new-console-template for more information


public class Test {
    public static int Factorial(int number) {
        Factorial(number - 1);
        // if number equals 1 or 0 we return 1
        if (number == 1 || number == 0) {
            return 1;
        } else {
            //recursively calling the function if n is other then 1 or 0
            return number;
        }
    }

    // static void Main() {
    //     Console.WriteLine("Factorial of 4 is: {0}", Factorial(4));
    // }
    static void Main(string[] args) {
        int b = 0;
        try {
           int a =  1 / b;
        } catch (ArithmeticException ex) {
            Console.WriteLine("Error: " + ex);
        } finally {
            Console.WriteLine("Finished!");
        }
        
    }
}