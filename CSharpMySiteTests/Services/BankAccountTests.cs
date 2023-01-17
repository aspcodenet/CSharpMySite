using System.Diagnostics.Eventing.Reader;
using CSharpMySite.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace CSharpMySiteTests.Services;

[TestClass]
public class BankAccountTests
{
    private BankAccount sut; // SYSTEM UNDER TEST
    public BankAccountTests()
    {
        sut = new BankAccount();
    }


    [TestMethod]
    public void When_withdraw_and_all_is_ok_balance_should_be_updated()
    {
        //Arrange  
        sut.Balance = 2000;
        int amount = 500;

        // Act
        var result = sut.Withdraw(amount);

        // Assert
        Assert.AreEqual(BankAccountStatus.Ok, result);
        Assert.AreEqual(1500, sut.Balance);
    }




    [TestMethod]
    public void When_withdraw_more_than_balance_should_give_errorcode()
    {
        //Arrange  
        sut.Balance = 2000;
        int amount = 2001;

        // Act
        var result = sut.Withdraw(amount);

        // Assert
        Assert.AreEqual(BankAccountStatus.NotEnoughBalance, result);
        Assert.AreEqual(2000, sut.Balance );
    }



    
    [TestMethod]
    public void When_withdraw_more_than_4000_should_give_errorcode()
    {
        //Arrange
        int amount = 4001;
        sut.Balance = 5000;

        // Act
        var result = sut.Withdraw(amount);

        // Assert
        Assert.AreEqual(BankAccountStatus.TooBigAmount, result);
        Assert.AreEqual(5000, sut.Balance);
    }


    [TestMethod]
    public void When_deposit_balance_should_be_increased()
    {
        //Arrange
        sut.Balance = 500;

        // Act
        var result = sut.Deposit(100);

        // Assert
        Assert.AreEqual(BankAccountStatus.Ok, result);
        Assert.AreEqual(600, sut.Balance);
    }

}