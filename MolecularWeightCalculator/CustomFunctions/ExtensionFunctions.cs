using NCalc;
using System;

public static class ExtensionFunctions
{
    public static void RegisterCustomFunctions(Expression e)
    {
        RegisterDaysFunction(e);
        RegisterDaysTwFunction(e);
    }


    private static void RegisterDaysFunction(Expression e)
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

    //增加 DaysTW 函数 for 民國年
    private static void RegisterDaysTwFunction(Expression e)
    {
        e.EvaluateFunction += (name, args) =>
        {
            if (name.Equals("DaysTW", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Parameters.Length != 2)
                    throw new ArgumentException("DaysTW function expects 2 parameters.");
                //end date
                var dateStr1 = args.Parameters[0].Evaluate().ToString();
                //start date
                var dateStr2 = args.Parameters[1].Evaluate().ToString();

                // 支援民國年轉換
                DateTime date1, date2;
                if (!TryParseTwDate(dateStr1, out date1) || !TryParseTwDate(dateStr2, out date2))
                {
                    throw new ArgumentException("Invalid date format for DaysTW function.");
                }
                args.Result = (date1 - date2).TotalDays;
            }
        };
    }
    // 民國年字串轉西元年
    private static bool TryParseTwDate(string input, out DateTime date)
    {
        input = input.Trim();
        // 支援格式：yyy/MM/dd 或 yyy-M-d
        // 檢查是否為民國年
        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{2,3}[-/]\d{1,2}[-/]\d{1,2}$"))
        {
            // 拆解民國年
            var parts = input.Split(new char[] { '/', '-' });
            int rocYear;
            if (int.TryParse(parts[0], out rocYear))
            {
                int year = rocYear + 1911;
                var newDateStr = $"{year}/{parts[1]}/{parts[2]}";
                return DateTime.TryParse(newDateStr, out date);
            }
        }
        // 非民國年，走標準 DateTime.Parse
        return DateTime.TryParse(input, out date);
    }
}