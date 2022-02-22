
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Text.RegularExpressions;
using DorzerLicense.Data.Models;

using System.Net.Mail;

using System.Net;
using POSERPAPI.Utilities;

namespace POSERPAPI.Manager.Helper
{
    public static class HelperFunctions
    {
        public static string GeneratePassword(int length)
        {
            int maxSize = length;
            char[] chars = new char[30];
            string a;
            a = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ*%$#@";

            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }

            return result.ToString();
        }

        
        public static string SendOpt(string mobileNo)
        {
            string OptResult = string.Empty;
            //For generating OTP
            Random r = new Random();
            OptResult = r.Next(1000, 9999).ToString();

            return OptResult;

        }

        
       
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
            return result;
        }
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionary)
            {
                // if the value can also be turned into an ExpandoObject, then do it!
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection<object>)
                {
                    // iterate through the collection and convert any strin-object dictionaries
                    // along the way into expando objects
                    var itemList = new List<object>();
                    foreach (var item in (ICollection<object>)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }

        public static int CalculateAge(DateTime birthDate, DateTime now)
        {
            DateTime firstDate = now;
            DateTime secondDate = birthDate;

            int totalYears = firstDate.Year - secondDate.Year;
            int totalMonths = 0;

            if (firstDate.Month > secondDate.Month)
                totalMonths = firstDate.Month - secondDate.Month;
            else if (firstDate.Month < secondDate.Month)
            {
                totalYears -= 1;
                int monthDifference = secondDate.Month - firstDate.Month;
                totalMonths = 12 - monthDifference;
            }

            if ((firstDate.Day - secondDate.Day) == 30)
            {
                totalMonths += 1;
                if (totalMonths % 12 == 0)
                {
                    totalYears += 1;
                    totalMonths = 0;
                }
            }

            return totalYears;
        }


        public static TSelf TrimStringProperties<TSelf>(this TSelf input)
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));
            foreach (var stringProperty in stringProperties)
            {
                string propertyValue = (string)stringProperty.GetValue(input, null);
                if (propertyValue != null)
                    stringProperty.SetValue(input, propertyValue.Trim(), null);
            }

            var stringFields = input.GetType().GetFields()
                .Where(f => f.FieldType == typeof(string));
            foreach (var stringField in stringFields)
            {
                string fieldValue = (string)stringField.GetValue(input);
                if (fieldValue != null)
                    stringField.SetValue(input, fieldValue.Trim());
            }

            return input;
        }

        public static string RemoveCountryCodeInCellPhones(string CellPhone)
        {
            if (!string.IsNullOrEmpty(CellPhone))
            {
                if (CellPhone.StartsWith("+27") || CellPhone.StartsWith("27"))
                {
                    CellPhone = CellPhone.Replace("+", string.Empty);
                    CellPhone = Regex.Replace(CellPhone, "^27", "0");

                }
            }

            return CellPhone;
        }

       

    }
}
