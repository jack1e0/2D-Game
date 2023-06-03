using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class BaseCharacter
{
    public static string[] characters;
    public static string[] lines;
}

public class Man : BaseCharacter
{
    new public static string[] characters = { "Man", "Dog", "Man", "Dog", "Man" };
    new public static string[] lines = {"Hello doggy, out alone are we?", "...", "Well, where is that owner of yours? Everytime I see you, you get skinnier!",
                              "...", "Well, run along now."};
}

public class Police : BaseCharacter
{
    new public static string[] characters = { "Police", "Police", "Police", "Police", "Police", "Police", "Police" };
    new public static string[] lines = {"Sigh... what a nasty case.", "The old drunk's done for." , "Killing a person..." , "...barely a few days after a previous crime..." ,
                                    "What was it again?", "...", "Ugh, why is it so chilly? Gives me the jitters." };

}

public class Women : BaseCharacter
{
    new public static string[] characters = { "Lady 1", "Lady 2", "Lady 2", "Lady 1", "Lady 1", "Lady 2", "Lady 1" };
    new public static string[] lines = {"Have you heard the rumour lately?",
                              "Yes, I heard that the old man down the street got arrested!", "Apparently he beat somebody up.",
                              "A leopard never changes its spots...",  "He got into trouble a few times for violence in the past.",
                              "And I used to hear terrible barking from his house!", "Wonder how his poor dog is holding up..."};
}

public class Victim : BaseCharacter
{
    new public static string[] characters = { "Dog", "...Ghost?", "...Ghost?", "Dog", "...Ghost", "...Ghost", "...Ghost", "Dog", "Ghost", "Ghost", "Dog" };
    new public static string[] lines = {"Woof!", "Oh hey doggy...", "I will talk to you, since no one else can see me.", "* Wags tail *",
                                   "I have got to vent my anger...",
                                   "A few days ago I was beat up by some drunkard!", "The next thing I know, I am stuck here...",
                                   "..." , "It would be nice to have some company...", "..." , "..." };
}

public class Blood : BaseCharacter
{
    new public static string[] characters = { };
    new public static string[] lines = { "* Sniffs *", "( Red... splatters...? )" };
}

public class FinalThoughts : BaseCharacter
{
    new public static string[] characters = { };
    new public static string[] lines = { "will i see him soon?" };
}
