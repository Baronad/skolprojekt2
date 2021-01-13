
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "you may type menu att any time";
    string[] level1Passwords = { "lable, chesse, key, chair, fork" };
    string[] level2Passwords = { "abnormal, computer, charge, processor, chassi" };
    string[] level3Passwords = { "lawyer, advocate, alias, alibi, attorney" };
    string[] level4Passwords = { "capitulate, duplicity, maverick, neglect, insurgent" };
    //game state
    int level;
    // Start is called before the first frame update
    enum Screen 
    //Basically a restaurant menu
    //TODO handle differently depending on which screen you are on
    {
        Mainmenu, Password, Win
    };

    Screen currentScreen;
    string password;

    void Start()
    {
        ShowMainMenu("Hello player!");
    }



    void ShowMainMenu()
    {
        Screen currentScreen = Screen.Mainmenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose a target to hack into");
        Terminal.WriteLine("Press 1 for the kitchen");
        Terminal.WriteLine("Press 2 for the computer room");
        Terminal.WriteLine("Press 3 for the lawyer firm");
        Terminal.WriteLine("Press 4 for professional");
    }
    void OnUserInput(string input)

    //This shit should only decide how to handle user input, not do it
    {
        if (input == "menu") //We can always write menu to go to menu  //bolean = true or false
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Mainmenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckForPassword(input);

        }
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
   

        else if (input == "3")
        {
            level = int.Parse(input);
            password = "mouse";



        }

        else if (input == "4")
        {
            level = int.Parse(input);
            password = "low";
        }

        else if (input == "5")
        {
            level = int.Parse(input);
            password = "666";
            Terminal.WriteLine("Please select your level satan");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password, hint: " + password.Anagram());
        Terminal.WriteLine("menuHint");



        void SetRandomPassword()
        {
            Terminal.ClearScreen();
            switch (level)
            {
                case 1:
                    Terminal.WriteLine("You've chosen kitchen");
                    password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                    Terminal.WriteLine("Here's a clue, ikthcne");
                    break;

                case 2:
                    Terminal.WriteLine("You've chosen chosen computer room");
                    password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                    Terminal.WriteLine("Here's a clue, oumse");
                    break;

                case 3:
                    Terminal.WriteLine("You've chosen chosen lawyer firm");
                    password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                    Terminal.WriteLine("Here's a clue, awl");
                    break;

                case 4:
                    Terminal.WriteLine("You've chosen chosen professional");
                    password = level4Passwords[Random.Range(0, level4Passwords.Length)];
                    Terminal.WriteLine("You don't need a clue, already2hard");
                    break;

                default:
                    Debug.LogError("Invalid level number");
                    break;
            }
            Terminal.WriteLine("Please enter your password");
        }
        void CheckPassword(string input)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                AskForPassword();
            }

        }

        void DisplayWinScreen()
        {
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            ShowlevelReward();
        }

        void ShowlevelReward()
        {
            switch (level)
            {
                case 1:
                    Terminal.WriteLine("You solved the puzzle!");
                    Terminal.WriteLine(@"
  __      _
o'')}____//
 `_/      )
 (_(_/-(_/
                ");
                    Terminal.WriteLine("write whatever");
                    break;

                case 2:
                    Terminal.WriteLine("You solved the puzzle!");
                    Terminal.WriteLine(@"
         _____________
        ()___________()
        \ \Tom Riddle  \
         \ \   diary    \
          \ \____________\
           ()_____________()
        ");
                    Terminal.WriteLine("Play again for a greater challenge");
                    break;
                default:
                    Debug.LogError("Invalid level reached");
                    break;
            }
        }
    }
}