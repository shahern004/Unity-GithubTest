using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string[] level1Passwords = { "beef", "pork", "lamb", "veal", "fish" };
    string[] level2Passwords = { "shoulder", "ribeye", "porterhouse", "tomahawk", "flatiron" };
    
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win, EasterEgg };
    Screen currentScreen;
    string password;

    void Start()
    {
        print(level1Passwords[0]);
        ShowMainMenu ();
    }
    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Which section of the grocery store data center would you like to hack?");
        Terminal.WriteLine("Typing 'menu' will return you to the selection screen.");
        Terminal.WriteLine("1. The meat freezer");
        Terminal.WriteLine("2. The butcher shop");
        Terminal.WriteLine("3. The spice rack");
        Terminal.WriteLine("Enter your selection:"); 
    }

    void OnUserInput(string input) 
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else
        {
            CheckPassword(input);
        }
    
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2];/// todo make random later
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[3];
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "flavor";
            StartGame();
        }
        else if (input == "FFW")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("ROLL DEEP");
        }
        else
        {
            Terminal.WriteLine("That is not a vaild selection");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Please enter your password:");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("You have cracked the database");
        }
        else
        {
            Terminal.WriteLine("Access Denied");
        }
        
    }

}