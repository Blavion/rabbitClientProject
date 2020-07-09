namespace HumanDatabase
{
    public class Customer
    {
        private string name;
        private int age;
        private string gender;

    
        public Customer(string Name, int Age, string Gender){
            name = Name;
            age = Age;
            gender = Gender;
        }
        public override string ToString(){
            return "Name: " + name + " , Age: " + age.ToString() + " , Gender: " + gender;
        }
    
    
    }

}