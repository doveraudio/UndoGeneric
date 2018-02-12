A Library to provide Undo functionality, with depth and size limits.
All core features implemented, see example in test project.
Basic Usage:

    List<string> ourList = new List<string>(new string[] { "plastics", "hardware", "housewares", "toys" });
    Undo<List<string>> history = new Undo<List<string>>();
    history.AddItem(new List<string>(ourList.ToArray()));
    string currentSize = history.GetSize().ToString();
    Console.WriteLine("Current Size: {0}", currentSize);
       
See Example Project for more in depth usage.
Bugs/Features please post in issues.                    