using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CSharpMySite.Services;

public class StringCalculator
{
    // if passing empty string ->  0
    // skickar in ett endaste nummer -> numret
    // skickar sin flera -> summan av 
    // tal över 1000 ska ignoreras  -> 1,1101,2  -> 3
    public int Summarize(string csvNumbers)
    {
        csvNumbers = csvNumbers ?? "";
        //return csvNumbers.Split(',', StringSplitOptions.RemoveEmptyEntries)
        //    .Select(x => Convert.ToInt32(x)).Where(e=>e < 1000).Sum();
        var summa = 0;
        foreach (var part in csvNumbers.Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(e => Convert.ToInt32(e)).Where(e => e < 1000))
            summa += part;
        return summa;

    }

    //public int Summarize(string csvNumbers)
    //{
    //    if (string.IsNullOrEmpty(csvNumbers))
    //        return 0;

    //    if (csvNumbers.Contains(',')) // "FLERA"
    //    {
    //        var summa = 0;
    //        foreach (var part in csvNumbers.Split(',').Select(e => Convert.ToInt32(e)).Where(e => e < 1000))
    //            summa += part;
    //        return summa;
    //        //return csvNumbers.Split(',').Sum(Convert.ToInt32);
    //    }

    //    var number = Convert.ToInt32(csvNumbers);
    //    if(number > 1000) return 0;

    //    return number;
    //}
}