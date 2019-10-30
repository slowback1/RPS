using System;

namespace RPS
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to my Rock-Paper-Scissors game!");
            Model M = new Model();
            Controller C = new Controller(M);
            new View(M, C);



        }

    }
}
/*To-do:
 * -write more comments
 * -git this on github
 * -add to andrewwobeck.com
 * 
 * 
 * 
 */
