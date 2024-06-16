
using System.Text.RegularExpressions;

class UI{

    public static void SystemHeader()
    {
        Console.Clear();
        Console.ResetColor();
        Console.WriteLine("#----------------------------------#");
        Console.WriteLine("#  RENTAL CAR SYSTEM               #");
        Console.WriteLine("#  By Rodrigo Bruner               #");
        Console.WriteLine("#  Studen #: 8993586               #");
        Console.WriteLine("#  rbruner3586@conestogac.on.ca    #");
        Console.WriteLine("#----------------------------------#\n\n");
    }


    public static int IntField(string question, int start = 1,  int end = 4 )
    {
        int number;
        bool notValid = false;
        do{ //while number is less than 0
            notValid = true;
            // show the question on console
            ShowQuestion($"\n{question}");
        
            // recive the answer
            string? sNumber = Console.ReadLine(); 
        
            // Tray parse string to int
            bool parseResult = int.TryParse(sNumber! , out number);
            //If is not successeful show a error mensage
            if (!parseResult) {
                ShowErrorMessages("Invalid number, please try again");
                notValid = false;
            }

            if (number < start || number > end){
                ShowErrorMessages("Invalid number, please try again");
                notValid = false;
            }

        }while(!notValid);
        return number; //Return informed number
    }

    public static string CustumerIDField(string question){

        bool notValid = false; 
        string? custumerID = "";
        string regex =  @"^[a-zA-Z0-9]{6}$";  

        do{ //while not valid

            notValid = true;

            // show the question on console
            ShowQuestion($"\n{question}");
        
            // recive the answer
            custumerID = Console.ReadLine(); 

            if(!Regex.Match(custumerID!, regex).Success){
                ShowErrorMessages("Invalid custumer ID, please try again");
                notValid = false;
            }
        
        }while(!notValid);
        return custumerID!;
    }
    public static string textField(string question){
        Console.WriteLine(question);
        var answer = Console.ReadLine()?.Trim();
        return answer!;
    }


    //Ask for a phone number
    public static string PhoneField(string question){

        bool notValid = false; 
        string? phoneNumber = "";
        string regex =  @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";  

        do{ //while not valid

            notValid = true;

            // show the question on console
            ShowQuestion($"\n{question}");
        
            // recive the answer
            phoneNumber = Console.ReadLine(); 

            if(!Regex.Match(phoneNumber!, regex).Success){
                ShowErrorMessages("Invalid phone number, please try again");
                notValid = false;
            }
        
        }while(!notValid);
        return phoneNumber!;
    }

    
    //Ask, recive and validate a yes/no y/n answer
    public static bool YesNoField(string question)
    {
        bool result = false;    // recive the answer
        bool valid = false;     // is a valid answer
        while (!valid)
        {
            ShowQuestion($"\n{question} (Entre Y/N or YES/NO)");
            string? answer = Console.ReadLine();
            answer = answer?.ToLower();     //transfor string to lowercase
            answer = answer?.Trim();        //remove whitespaces
    
            if (answer == "y" || answer == "yes") { //check the answer is yes and return true
                result = true;
                valid = true;
            } else if (answer == "n" || answer == "no") { //check the answer is no and return false
                result = false;
                valid = true;
            } else { //If answer is not yes or no show a error mensage
                ShowErrorMessages("Invalid answer, please try again");
            }
        }
        return result;
    }

    // Show a error mensage
    public static void ShowErrorMessages(string message){
        Console.ForegroundColor = ConsoleColor.Red; // change font color to red
        Console.WriteLine(message); //show menssage
        Console.ResetColor(); // reset font color
    }

    public static void ShowInfoMessages(string message){
        Console.ForegroundColor = ConsoleColor.Blue; // change font color to red
        Console.WriteLine(message); //show menssage
        Console.ResetColor(); // reset font color
    }

    
    public static void ShowQuestion(string message){
        Console.ForegroundColor = ConsoleColor.Yellow; // change font color to red
        Console.WriteLine(message); //show menssage
        Console.ResetColor(); // reset font color
    }

    // Show a success mensage
    public static void ShowSuccessMessages(string message){
        Console.ForegroundColor = ConsoleColor.Green; // change font color to green
        Console.WriteLine(message); //show menssage
        Console.ResetColor(); // change font color to red
    }


    public static void Debug(string message){
        Console.BackgroundColor = ConsoleColor.Red; // change font color to red
        Console.WriteLine(message); //show menssage
        Console.ResetColor(); // reset font color
    }
}