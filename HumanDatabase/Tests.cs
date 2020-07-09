using System;
using Xunit;
using System.Threading;
namespace HumanDatabase
{
    public class Tests
    {
        /*
        For the class HumanDatabase.
        -------------------------------------------------------------
        Note: that some of the functions does not get test as they are
        Private and therefore not testable isolated. They are tested
        through the calls of the other functions.
        */
        
        /*
        This test ensures that a customer can be added.
        It also ensures that The whole array is not instantiated
        with instances of people.
        */
        [Fact]
        public void TestAddCustomer()
        {
        //Given
        Database db = Database.GetDB();
        string _input = "Astrid 22 Female";
        string[] _Customer = _input.Split(" ");
        //When
        db.AddCustomer(_Customer[0], Int32.Parse(_Customer[1]), _Customer[2]);
        //Then
        Assert.NotNull(db.GetIndex(0));
        Assert.Null(db.GetIndex(1));
        }
        

        
        //This test shows a possible vulnerbility by closing the db and then calling methods.
        [Fact]
        public void TestCloseDB()
        {
        //Given
        Database db = Database.GetDB();  
        string _input = "Astrid 22 Female";
        string[] _Customer = _input.Split(" ");
        //When
        db.CloseDB();
        //Then
        Assert.Throws<NullReferenceException>(() => db.AddCustomer(_Customer[0], Int32.Parse(_Customer[1]), _Customer[2]));
        Assert.Throws<NullReferenceException>(() => db.GetIndex(0));
        }


        /*
        Tests for the Broadcaster class.
        ---------------------------------------------------------------------------------------
        */

        [Fact]
        public void TestSendMessage()
        {
        //Given
        var _broadcaster = new Broadcaster();
        //When
        _broadcaster.CloseConnection();
        //Then
        Assert.Throws<RabbitMQ.Client.Exceptions.AlreadyClosedException>(() => _broadcaster.SendMessage("Log", "test"));
        Assert.Throws<RabbitMQ.Client.Exceptions.AlreadyClosedException>(() => _broadcaster.SendMessage("Customer", "test"));
        }

        /*
        Tests for Customer.
        --------------------------------------------------------------
        */
        [Fact]
        public void TestCustomerToString()
        {
        //Given
        var name = "Astrid";
        var age = 32;
        var gender = "Female";
        //When
        var astrid  = new Customer(name, age, gender);
        //Then
        Assert.Equal("Name: Astrid , Age: 32 , Gender: Female", astrid.ToString());
        }

    }
}