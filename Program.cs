using System.Diagnostics;
using System.Threading.Channels;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ToDoList
{
    internal class Program
        {List<ListToDo> lstToDo= new List<ListToDo>();          
           string Path="toDo.xml";
            static void Main(string[] args)
        {
              
            WasJetzt();

        }

private static void WasJetzt(){
    int wahl=Menu();
    switch(wahl){
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
// Zakończenie programu z kodem wyjścia 1 (błąd)
Environment.Exit(1);
break;
        default: 
        break;    
    }
}

        private static int Menu()
{
    int wahl = -1;
    bool validInput = false;

    while (!validInput)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Herzlich willkommen im ToDo List Manager.");
        Console.WriteLine(" ");
        Console.WriteLine("1. Aufgabe hinzufügen");
        Console.WriteLine("2. Alle Aufgaben anzeigen");
        Console.WriteLine("3. Aufgabe löschen");
        Console.WriteLine("4. Aufgaben in Datei speichern");
        Console.WriteLine("5. Aufgaben aus Datei laden");
        Console.WriteLine("6. Beenden");
        Console.WriteLine(" ");
        Console.WriteLine("Wähle eine Option:");

        string? w = Console.ReadLine();

        if (int.TryParse(w, out wahl))                      //checking ob kann mann unwaneln input to int
        {
            if (wahl >= 1 && wahl <= 6)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl zwischen 1 und 6 eingeben.");
                Console.ReadKey(); 
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe. Bitte eine gültige Zahl eingeben.");
            Console.ReadKey();
        }
    }

    return wahl;
}
private void ListSpeichern(){
    try{
        using (XmlWriter xmlWriter=XmlWriter.Create(Path)){
            XmlSerializer xmlSerializer=new XmlSerializer(typeof(ListToDo));
            xmlSerializer.Serialize(xmlWriter, lstToDo);  
        }
    }catch(Exception ex){System.Diagnostics.Debug.WriteLine(ex);}
}
private  void ToDoListLaden(){
    if(!File.Exists("toDo.xml")){return;}
    try
    {
        using (XmlReader xmlReader=XmlReader.Create(Path)){
            XmlSerializer xmlSerializer=new XmlSerializer(typeof(List<ListToDo>));
            lstToDo.Clear();
            lstToDo=xmlSerializer.Deserialize(xmlReader) as List<ListToDo>;
                        
        }
    }
    catch(Exception ex){System.Diagnostics.Debug.WriteLine(ex);}
}
    }



}

