using CSharpMySite.Services;

namespace CSharpMySiteTests.Services;

// if passing empty string ->  0
// skickar in ett endaste nummer -> numret
// skickar sin flera -> summan av 
// tal över 1000 ska ignoreras  -> 1,1101,2  -> 3

[TestClass]
public class StringCalculatorTests
{
    private StringCalculator sut;

    public StringCalculatorTests()
    {
        sut = new StringCalculator();
    }

    [TestMethod]
    public void When_passing_string_of_length_0_should_return_0()
    {
        //arrange
        string input = "";

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void When_passing_single_number_that_number_is_returned()
    {
        //arrange
        string input = "12";

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(12,result);   
    }


    [TestMethod]
    public void When_passing_single_number_larger_than_1000_zero_is_returned()
    {
        //arrange
        string input = "1555";

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(0, result);
    }




    [TestMethod]
    public void When_passing_multiple_number_sum_of_all_numbers_are_returned()
    {
        //arrange
        string input = "12,11,100";

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(123, result);
    }


    [TestMethod]
    public void When_passing_multiple_number_sum_of_all_numbers_less_than_1000_are_returned()
    {
        //arrange
        string input = "12,1100,100";

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(112, result);
    }




    [TestMethod]
    public void When_passing_null_string_return_0()
    {
        //arrange
        string input = null;

        //act
        var result = sut.Summarize(input);

        //assert
        Assert.AreEqual(0, result);
    }



}