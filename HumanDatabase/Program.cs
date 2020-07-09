using System;

namespace HumanDatabase
{
    /*
    --------------------------------------------------------
        This project is only for educational purposes, it is
        not an actual database and it does not store anything.
        The results should be output to a RabbitMQ queue.
    --------------------------------------------------------
    */
    class Program
    {
        static void Main(string[] args)
        {
            var db = Database.GetDB();
            bool IsRunning = true;
            
            Console.WriteLine("Welcome to Human Database. A new database has been made.\n" +
                              "Please enter a human. Format : (string)Name (int)Age (string)Gender");
            
            string _input = Console.ReadLine();
            
            // a function which makes sure there is no faulty input.
            void CheckInputAndAddCustomer(string input){
                bool CheckInput = true;
                while(CheckInput){
                    try
                    {
                        string[] input_arr = input.Split(" ");
                        db.AddCustomer(input_arr[0], Int32.Parse(input_arr[1]), input_arr[2]);
                        CheckInput = false;
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("wrong format of input. Input should be formatted: (string)Name (int)Age (string)Gender\n" 
                                        + "Please try again or exit by pressing CTRL c");
                    
                        input = Console.ReadLine();
                    }
                }
            }

            // The program loop.
            while (IsRunning)
            {
                switch (_input)
                {
                    case "": 
                        IsRunning = false; 
                        break;
                    default:
                        CheckInputAndAddCustomer(_input);
                        Console.WriteLine("Do you wish to add another customer? Otherwise press Enter");
                        _input = Console.ReadLine();
                        break;
                }
            }
            //Closes the RabbitMQ connection and sets the array to null.
            db.CloseDB();
        }
    }
}
