A Library to provide Undo functionality, with depth and size limits.
All core features implemented, see example in test project.
Basic Usage:

    List<string> ourList = new List<string>(new string[] { "plastics", "hardware", "housewares", "toys" });
    Undo<List<string>> history = new Undo<List<string>>();
    history.AddItem(new List<string>(ourList.ToArray()));
    ourList.Add("books");
    history.AddItem(new List<string>(ourList));
    ourList.Add("furniture");
    history.AddItem(new List<string>(ourList));
    ourList.Add("auto parts");
    history.AddItem(new List<string>(ourList));
    string currentSize = history.GetSize().ToString();
    Console.WriteLine("Current Size: {0}", currentSize);
    for (int i = 0; i < 15; i++)
            {
                history.Up();
                current = history.Current.Value;
                Console.WriteLine("Printing Item {0}: Time: {1} Date: {2};", history.Cursor.ToString(), history.Current.Time, history.Current.Date);
                foreach (var item in current)
                {
                    Console.Write(item + ",");
                }
                Console.WriteLine();

                Console.WriteLine("Moving Up:");
                Console.WriteLine();



            }
    Console.ReadKey(false);

       
See Example Project for more in depth usage.
Bugs/Features please post in issues.                    