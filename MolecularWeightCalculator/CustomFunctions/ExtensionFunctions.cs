using NCalc;
using System;

public static class ExtensionFunctions
{
    public static void RegisterCustomFunctions(Expression e)
    {
        REgisterDaysFunction(e);
    }


    private static void REgisterDaysFunction(Expression e)
    {
        e.EvaluateFunction += (name, args) =>
        {
            if (name.Equals("Days", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Parameters.Length != 2)
                    throw new ArgumentException("Days function expects 2 parameters.");
                //end date
                var dateStr1 = args.Parameters[0].Evaluate().ToString();
                //start date
                var dateStr2 = args.Parameters[1].Evaluate().ToString();

                if (DateTime.TryParse(dateStr1, out var date1) && DateTime.TryParse(dateStr2, out var date2))
                {
                    args.Result = (date1 - date2).TotalDays;
                }
                else
                {
                    throw new ArgumentException("Invalid date format for Days function.");
                }
            }
        };
    }

}