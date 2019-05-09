using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using YourDollar.API.Core.Models;


namespace YourDollar.API.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _mockAccount;
        private Person _mockPerson1;
        private Person _mockPerson2;

        [SetUp]
        public void Setup()
        {
            _mockAccount = new BankAccount
            {
                AccountName = "MockAccount",
                AccountOwners = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        PhoneNumber = "553-867-5309",
                        Email = "bla@blah.com"
                    }
                },
                AccountType = AccountTypes.CheckingAccount,
                Balance = 2000
            };

            _mockPerson1 = new Person()
            {
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "123-334-4456"
            };

            _mockPerson2 = new Person()
            {
                FirstName = "blah",
                LastName = "blahblah"
            };
        }

        [Test]
        public void BankAccount_AddFunds_IncreasesBalance()
        {
            _mockAccount.AddFunds(200);
            Assert.AreEqual(2200,_mockAccount.Balance);
        }

        [Test]
        public void BankAccount_WithDrawFunds_DecreasesBalance()
        {
            _mockAccount.WithdrawFunds(1000);
            Assert.AreEqual(1000, _mockAccount.Balance);
        }
    }
}