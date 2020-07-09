using System;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            --------------------------------------
                This program is a listener to the
                HumanDatabase project. It has no
                real purpose and is for illustrating
                and personal education only.
            --------------------------------------
            */

            //Firstly it is needed to make sure that args is of correct input.
            bool argsCheck = new bool();
            argsCheck = true;
            string route = "";
            
            //no-input safety.
            while (argsCheck)
            {
                try
                {   
                    route = args[0];
                    argsCheck = false;
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("You have to provide input to this program. possible options is Log or Customer");
                    route = Console.ReadLine(); 
                }   
            }
            
            argsCheck = true;

            //
            while(argsCheck){
                switch (route)
                {
                    case "Customer":
                        argsCheck = false;
                        break;           
                    case "Log":
                        argsCheck = false;
                        break;         
                    default:
                        Console.WriteLine("Wrong input. Input must be either Customer or Log. Try again, or press Ctrl c to stop exit the program.");
                        route = Console.ReadLine();
                        break;
                }
            }

            //makes an obejct and makes it listen on the route.
            //the route is forced to be either 'Consumer' or 'Log'
            var receiver = new Receive(route);
            Console.WriteLine("Waiting for incoming messages");
            receiver.GetMessage();
        }
    }
}
