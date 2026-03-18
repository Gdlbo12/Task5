using System;

namespace AvaloniaApp;

public class NumeralNumber
{
    public long Value { get; private set; }

    private NumeralNumber(long value)
    {
        Value = value;
    }

    public static NumeralNumber Parse(string input, int fromBase)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Ввод пустой.");

        try
        {
            long val = Convert.ToInt64(input, fromBase);
            return new NumeralNumber(val);
        }
        catch (FormatException)
        {
            throw new FormatException($"Неверный формат числа.");
        }
    }

    public string ToString(int toBase)
    {
        return Convert.ToString(Value, toBase).ToUpper();
    }

    public static NumeralNumber operator +(NumeralNumber a, NumeralNumber b)
    {
        return new NumeralNumber(a.Value + b.Value);
    }

    public static NumeralNumber operator -(NumeralNumber a, NumeralNumber b)
    {
        return new NumeralNumber(a.Value - b.Value);
    }

    public static NumeralNumber operator *(NumeralNumber a, NumeralNumber b)
    {
        return new NumeralNumber(a.Value * b.Value);
    }
    
    public static string Compare(NumeralNumber a, NumeralNumber b)
    {
        if (a.Value > b.Value) return ">";
        if (a.Value < b.Value) return "<";
        return "==";
    }
}

public static class Logic
{
    public static string Calculate(string val1, int base1, string val2, int base2, string operation, int outBase)
    {
        try
        {
            NumeralNumber num1 = NumeralNumber.Parse(val1, base1);
            NumeralNumber num2 = NumeralNumber.Parse(val2, base2);
            NumeralNumber result;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    return $"Результат: {result.ToString(outBase)} (в {outBase}-й системе)";
                case "-":
                    result = num1 - num2;
                    return $"Результат: {result.ToString(outBase)} (в {outBase}-й системе)";
                case "*":
                    result = num1 * num2;
                    return $"Результат: {result.ToString(outBase)} (в {outBase}-й системе)";
                case "Сравнить":
                    string comp = NumeralNumber.Compare(num1, num2);
                    if (comp == "==") return "Результат: Числа равны";
                    return $"Результат: Число 1 {comp} Число 2";
                default:
                    return "Ошибка: Неизвестная операция";
            }
        }
        catch (Exception)
        {
            return $"Ошибка";
        }
    }
}
