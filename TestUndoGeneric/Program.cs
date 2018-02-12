using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndoGeneric;

namespace TestUndoGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLn("Creating List!");
            List<string> ourList = new List<string>(new string[] { "plastics", "hardware", "housewares", "toys" });
            PrintLn("Creating Undo History");
            Undo<List<string>> history = new Undo<List<string>>();
            PrintLn("Adding List to Undo History");
            history.AddItem(new List<string>(ourList.ToArray()));
            PrintLn("Aquiring Statistics");
            string currentSize = history.GetSize().ToString();
            PrintLn("Current Size: {0}", currentSize);
            PrintLn();
            PrintLn("Adding Item 'garden'");
            ourList.Add("garden");
            history.AddItem(new List<string>(ourList.ToArray()));
            PrintLn("Getting History");
            PrintLn("Latest Item");

            List<string> current = history.Current.Value;
            PrintLn("Printing Item {0}:", history.Cursor.ToString());
            foreach (var item in current)
            {
                Print(item + ",");
            }
            PrintLn();
            PrintLn("Aquiring Statistics");
            currentSize = history.GetSize().ToString();
            PrintLn("Current Size: {0}", currentSize);
            PrintLn();

            PrintLn();
            PrintLn("-----------------");
            PrintLn("Changing Index to First");
            history.SetIndex(0);
            current = history.Current.Value;
            PrintLn("Printing Item {0}:", history.Cursor.ToString());
            foreach (var item in current)
            {
                Print(item + ",");
            }
            PrintLn();
            PrintLn("Aquiring Statistics");
            currentSize = history.GetSize().ToString();
            PrintLn("Current Size: {0}", currentSize);
            PrintLn();
            PrintLn("-----------------");
            PrintLn();

            PrintLn("Adding Items, 'books, furniture, auto parts' ");

            ourList.Add("books");

            history.AddItem(new List<string>(ourList));

            ourList.Add("furniture");

            history.AddItem(new List<string>(ourList));
            ourList.Add("auto parts");

            history.AddItem(new List<string>(ourList));



            current = history.Current.Value;
            PrintLn("Printing Item {0}:", history.Cursor.ToString());
            foreach (var item in current)
            {
                Print(item + ",");
            }
            PrintLn();
            PrintLn("Aquiring Statistics");
            currentSize = history.GetSize().ToString();
            PrintLn("Current Size: {0}", currentSize);
            PrintLn();

            PrintLn("Running through Up/Down:");

            for (int i = 0; i < 15; i++)
            {
                history.Up();
                current = history.Current.Value;
                PrintLn("Printing Item {0}: Time: {1} Date: {2};", history.Cursor.ToString(), history.Current.Time, history.Current.Date);
                foreach (var item in current)
                {
                    Print(item + ",");
                }
                PrintLn();

                PrintLn("Moving Up:");
                PrintLn();



            }

            for (int i = 0; i < 15; i++)
            {
                history.Down();
                current = history.Current.Value;
                PrintLn("Printing Item {0}: Time: {1} Date: {2};", history.Cursor.ToString(), history.Current.Time, history.Current.Date);
                foreach (var item in current)
                {
                    Print(item + ",");
                }
                PrintLn();

                PrintLn("Moving Down:");
                PrintLn();


            }


            AnyKey();
        }


        static void PrintLn()
        {

            Console.WriteLine("");
        }
        static void PrintLn(string Text)
        {

            Console.WriteLine(Text);
        }

        static void PrintLn(string Text, string Value1)
        {

            Console.WriteLine(Text, Value1);
        }
        static void PrintLn(string Text, string Value1, string Value2)
        {

            Console.WriteLine(Text, Value1, Value2);
        }
        static void PrintLn(string Text, string Value1,string Value2, string Value3)
        {

            Console.WriteLine(Text, Value1, Value2, Value3);
        }
        static void Print(string Text)
        {
            Console.Write(Text);
        }

        static void Print(string Text, string Value1)
        {

            Console.Write(Text, Value1);
        }
        static void Print(string Text, string Value1, string Value2)
        {

            Console.Write(Text, Value1, Value2);
        }
        static void Print(string Text, string Value1, string Value2, string Value3)
        {

            Console.Write(Text, Value1, Value2, Value3);
        }
        static void AnyKey()
        {
            Console.ReadKey(false);
        }
    }


}
