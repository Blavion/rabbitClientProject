using System;
namespace HumanDatabase
{
    public class Database
    {
        private static Database instance;
        public Customer[] DB;
        private int CustomerCount;
        private Broadcaster messenger;

        // Singleton pattern.
        public static Database GetDB(){
            if (instance == null){
                instance = new Database();
                instance.DB = new Customer[10];
                instance.CustomerCount = 0;
                instance.messenger = new Broadcaster();
                instance.messenger.SendMessage("Log","Human Database was created");
            }
            return instance;
        }

        //Dynamic array update (works only with increase)
        private void CheckDB(){
            if (DB.Length*0.75 < CustomerCount){
                int count = 0;
                var tempArr = new Customer[2*DB.Length];
                foreach (var cus in DB)
                {
                    tempArr[count] = cus;
                    count++;
                }
                DB = tempArr;
                messenger.SendMessage("Log", "Expanded Database, New Length is: "+ DB.Length.ToString());
            }
        }
        //Adds a customer to the "Database" and sends a message to Log and Customer queues.
        public void AddCustomer(string Name ,int Age ,string Gender){
            CheckDB();
            var cust = new Customer(Name, Age, Gender);
            DB[CustomerCount] = cust;
            CustomerCount++;
            messenger.SendMessage("Customer", "Customer: " + cust.ToString() + " has been added to the human database, Welcome!" );
            messenger.SendMessage("Log", "Customer: " + cust.ToString() + " has been added to the human database" );
            Console.WriteLine("Human added");
        }
        //Deletes the "Database" and notifies Customers and Log
        public void CloseDB(){
            DB = null;
            Console.WriteLine("Database deleted");
            messenger.SendMessage("Log", "Database deleted");
            messenger.SendMessage("Customer", "Error: Oops, something went wrong");
            messenger.SendMessage("Log", "Customers is notified with meaningfull error statement");
            messenger.CloseConnection();
        }

        public Customer GetIndex(int index){
            return DB[index];
        }
    }
}