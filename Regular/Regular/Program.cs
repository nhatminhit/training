﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
public class Regular
{
    public static void Main()
    {
        // //Dang 1
        // string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
        // string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
        //                  "Abraham Adams", "Ms. Nicole Norris" };
        //foreach (string name in names)
        //Console.WriteLine(Regex.Replace(name, pattern, String.Empty));


        ////Dang 2
        //string pattern = @"\b(\w+?)\s\1\b";
        //string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.";
        //foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
        //    Console.WriteLine("{0} (duplicates '{1}') at position {2}",
        //                    match.Value, match.Groups[1].Value, match.Index);

        //Dang3
        string input = "Office expenses on 2/13/2008:\n" +
                      "Paper (500 sheets)                      $3.95\n" +
                      "Pencils (box of 10)                     $1.00\n" +
                      "Pens (box of 10)                        $4.49\n" +
                      "Erasers                                 $2.19\n" +
                      "Ink jet printer                        $69.95\n\n" +
                      "Total Expenses                        $ 81.58\n";

        // Get current culture's NumberFormatInfo object.
        NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        // Assign needed property values to variables.
        string currencySymbol = nfi.CurrencySymbol;
        bool symbolPrecedesIfPositive = nfi.CurrencyPositivePattern % 2 == 0;
        string groupSeparator = nfi.CurrencyGroupSeparator;
        string decimalSeparator = nfi.CurrencyDecimalSeparator;

        // Form regular expression pattern.
        string pattern = Regex.Escape(symbolPrecedesIfPositive ? currencySymbol : "") +
                         @"\s*[-+]?" + "([0-9]{0,3}(" + groupSeparator + "[0-9]{3})*(" +
                         Regex.Escape(decimalSeparator) + "[0-9]+)?)" +
                         (!symbolPrecedesIfPositive ? currencySymbol : "");
        Console.WriteLine("The regular expression pattern is:");
        Console.WriteLine("   " + pattern);

        // Get text that matches regular expression pattern.
        MatchCollection matches = Regex.Matches(input, pattern,
                                                RegexOptions.IgnorePatternWhitespace);
        Console.WriteLine("Found {0} matches.", matches.Count);

        // Get numeric string, convert it to a value, and add it to List object.
        List<decimal> expenses = new List<Decimal>();

        foreach (Match match in matches)
            expenses.Add(Decimal.Parse(match.Groups[1].Value));

        // Determine whether total is present and if present, whether it is correct.
        decimal total = 0;
        foreach (decimal value in expenses)
            total += value;

        if (total / 2 == expenses[expenses.Count - 1])
            Console.WriteLine("The expenses total {0:C2}.", expenses[expenses.Count - 1]);
        else
            Console.WriteLine("The expenses total {0:C2}.", total);
    }
}