using System;
using System.Collections.Generic;

namespace Program.View
{
    public static class Menu
    {

        private const string ResultString = "Result Files -> ";
        private const string Comma = ", ";
        
        public static void ShowResult(HashSet<string> searchResult)
        {
            string result = ResultString;
            foreach (var name in searchResult)
            {
                result += name + Comma;
            }
            result = RemoveLastComma(result);
            ShowMessage(result);
        }

        private static string RemoveLastComma(string message)
        {
            return message.Substring(0, message.Length - 2);
        }
        
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}