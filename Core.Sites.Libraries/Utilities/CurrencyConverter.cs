using System;
using Core.Utility;

/// <summary>
/// Convert VietNam currency to string
/// </summary>
/// <Modified>
/// Name     Date         Comments
/// LongTQ  30-Dec-16   created
/// </Modified>
public abstract class CurrencyConverter<T> : Singleton<T> where T : class, new()
{
    private static readonly string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
    private static readonly string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };

    public string ToString(decimal number)
    {
        var s = number.ToString("#");
        int i, j, donvi, chuc, tram;
        var str = " ";
        bool booAm = false;
        decimal decS = 0;
        try
        {
            decS = Convert.ToDecimal(s.ToString());
        }
        catch
        {}

        if (decS < 0)
        {
            decS = -decS;
            s = decS.ToString();
            booAm = true;
        }
        i = s.Length;
        if (i == 0) str = so[0] + str;
        else
        {
            j = 0;
            while (i > 0)
            {
                donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                i--;
                if (i > 0)
                    chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                else
                    chuc = -1;
                i--;
                if (i > 0)
                    tram = Convert.ToInt32(s.Substring(i - 1, 1));
                else
                    tram = -1;
                i--;
                if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                    str = hang[j] + str;
                j++;
                if (j > 3) j = 1;
                if ((donvi == 1) && (chuc > 1)) str = " một " + str;
                else
                {
                    if ((donvi == 5) && (chuc > 0))
                        str = " lăm " + str;
                    else if (donvi > 0)
                        str = so[donvi] + " " + str;
                }
                if (chuc < 0) break;
                else
                {
                    if ((chuc == 0) && (donvi > 0)) str = " lẻ " + str;
                    if (chuc == 1) str = " mười " + str;
                    if (chuc > 1) str = so[chuc] + " mươi " + str;
                }
                if (tram < 0) break;
                else
                {
                    if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                }
                str = $" {str}";
            }
        }
        if (booAm) str = $" Âm {str}";
        return $"{str.Trim()} {Unit}";
    }

    protected abstract string Unit { get; }
}

public class CurrencyType
{
    /// <summary>
    /// Viet Nam Dong
    /// </summary>
    public class VND : CurrencyConverter<VND>
    {
        protected override string Unit
        {
            get { return "đồng chẵn"; }
        }
    }

    /// <summary>
    /// United States of America
    /// </summary>
    public class USD : CurrencyConverter<USD>
    {
        protected override string Unit
        {
            get { return "đô la"; }
        }
    }

    public static string Ones(string numberInput)
    {
        var _number = Convert.ToInt32(numberInput);
        string name = string.Empty;
        switch (_number)
        {
            case 1:
                name = "One";
                break;
            case 2:
                name = "Two";
                break;
            case 3:
                name = "Three";
                break;
            case 4:
                name = "Four";
                break;
            case 5:
                name = "Five";
                break;
            case 6:
                name = "Six";
                break;
            case 7:
                name = "Seven";
                break;
            case 8:
                name = "Eight";
                break;
            case 9:
                name = "Nine";
                break;
        }
        return name;
    }

    public static string Tens(string numberInput)
    {
        int number = Convert.ToInt32(numberInput);
        string name = string.Empty;
        switch (number)
        {
            case 10:
                name = "Ten";
                break;
            case 11:
                name = "Eleven";
                break;
            case 12:
                name = "Twelve";
                break;
            case 13:
                name = "Thirteen";
                break;
            case 14:
                name = "Fourteen";
                break;
            case 15:
                name = "Fifteen";
                break;
            case 16:
                name = "Sixteen";
                break;
            case 17:
                name = "Seventeen";
                break;
            case 18:
                name = "Eighteen";
                break;
            case 19:
                name = "Nineteen";
                break;
            case 20:
                name = "Twenty";
                break;
            case 30:
                name = "Thirty";
                break;
            case 40:
                name = "Fourty";
                break;
            case 50:
                name = "Fifty";
                break;
            case 60:
                name = "Sixty";
                break;
            case 70:
                name = "Seventy";
                break;
            case 80:
                name = "Eighty";
                break;
            case 90:
                name = "Ninety";
                break;
            default:
                if (number > 0) name = $"{Tens(numberInput.Substring(0, 1) + "0")} {Ones(numberInput.Substring(1))}";
                break;
        }
        return name;
    }

    public static string ConvertWholeNumber(string numberInput)
    {
        string word = string.Empty;
        try
        {
            bool beginsZero = false;//tests for 0XX   
            bool isDone = false;//test if already translated   
            double dblAmt = Convert.ToDouble(numberInput);
            //if ((dblAmt > 0) && number.StartsWith("0"))   
            if (dblAmt > 0)
            {
                //test for zero or digit zero in a nuemric   
                beginsZero = numberInput.StartsWith("0");

                int numDigits = numberInput.Length;
                int pos = 0;//store digit grouping   
                string place = string.Empty;//digit grouping name:hundres,thousand,etc...   
                switch (numDigits)
                {
                    case 1://ones' range   
                        word = Ones(numberInput);
                        isDone = true;
                        break;
                    case 2://tens' range   
                        word = Tens(numberInput);
                        isDone = true;
                        break;
                    case 3://hundreds' range   
                        pos = (numDigits % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4://thousands' range   
                    case 5:
                    case 6:
                        pos = (numDigits % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7://millions' range   
                    case 8:
                    case 9:
                        pos = (numDigits % 7) + 1;
                        place = " Million ";
                        break;
                    case 10://Billions's range   
                    case 11:
                    case 12:
                        pos = (numDigits % 10) + 1;
                        place = " Billion ";
                        break;
                    //add extra case options for anything above Billion...   
                    default:
                        isDone = true;
                        break;
                }
                if (!isDone)
                {//if transalation is not done, continue...(Recursion comes in now!!)   
                    if (numberInput.Substring(0, pos) != "0" && numberInput.Substring(pos) != "0")
                    {
                        try
                        {
                            word = ConvertWholeNumber(numberInput.Substring(0, pos)) + place + ConvertWholeNumber(numberInput.Substring(pos));
                        }
                        catch { }
                    }
                    else
                    {
                        word = ConvertWholeNumber(numberInput.Substring(0, pos)) + ConvertWholeNumber(numberInput.Substring(pos));
                    }
                }
                //ignore digit grouping names   
                if (word.Trim().Equals(place.Trim())) word = string.Empty;
            }
        }
        catch { }
        return word.Trim();
    }

    public static string ConvertDecimals(string number)
    {
        string cd = string.Empty;
        for (int i = 0; i < number.Length; i++)
        {
            string digit = number[i].ToString();
            string engOne;
            if (digit.Equals("0"))
            {
                engOne = "Zero";
            }
            else
            {
                engOne = Ones(digit);
            }
            cd += " " + engOne;
        }
        return cd;
    }

    public static string ConvertToWordsWithCurrency(string numb, string currency)
    {
        string val = string.Empty, wholeNo = numb, andStr = string.Empty, pointStr = string.Empty;
        string endStr = currency + " Only";
        try
        {
            int decimalPlace = numb.IndexOf(".");
            if (decimalPlace > 0)
            {
                wholeNo = numb.Substring(0, decimalPlace);
                string points = numb.Substring(decimalPlace + 1);
                if (Convert.ToInt32(points) > 0)
                {
                    andStr = "and";// just to separate whole numbers from points/cents   
                    endStr = "Paisa " + endStr;//Cents   
                    pointStr = ConvertDecimals(points);
                }
            }
            val = string.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
        }
        catch { }
        return val;
    }

    public static string ConvertToWords(string numb)
    {
        string val = string.Empty, wholeNo = numb, andStr = string.Empty, pointStr = string.Empty;
        string endStr = string.Empty;
        try
        {
            int decimalPlace = numb.IndexOf(".");
            if (decimalPlace > 0)
            {
                wholeNo = numb.Substring(0, decimalPlace);
                string points = numb.Substring(decimalPlace + 1);
                if (Convert.ToInt32(points) > 0)
                {
                    andStr = "and";// just to separate whole numbers from points/cents   
                    endStr = "Paisa " + endStr;//Cents   
                    pointStr = ConvertDecimals(points);
                }
            }
            val = string.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
        }
        catch { }
        return val;
    }
}

