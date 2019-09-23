using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string password;
    string FFW;
    enum Screen { MainMenu, Password, Win, EasterEgg };
    string[] level1Passwords = {"Beef", "Deer", "Lamb", "Pork", "Chicken"};
    string[] level2Passwords = { "Ribeye", "Shoulder", "Tomahawk", "Rumproast", "Sirloin" };
    string[] level3Passwords = { "Paprika", "Peppercorn", "Worcestershire", "Rosemary", "Balsamic" };
    Screen currentScreen;

    void Start()
    {
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
        else if (currentScreen == Screen.Password)
            {
            PasswordCheck(input);
            }
    
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == FFW);
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "FFW")
        {
            Terminal.WriteLine("ROLL DEEP");
        }
        else
        {
            Terminal.WriteLine("That is not a valid selection");
        }
    }
    void StartGame()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        switch(level)
        {
            case 1:
                password = level1Passwords[0];
                break;
            case 2:
                password = level2Passwords[0];
                break;
            case 3:
                password = level3Passwords[0];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
        Terminal.WriteLine("Please enter your password:");
    }

    void PasswordCheck(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("You have cracked the database!");
        }
        else
        {
            Terminal.WriteLine("That is not a vaild selection");
        }
    }

}