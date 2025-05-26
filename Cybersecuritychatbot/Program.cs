using System;
using System.Collections.Generic;
using System.Media;
using System.IO;

public class CybersecurityChatbot
{
    static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();
    static string userName = "";
    static string userInterest = "";

    static void Main(string[] args)
    {
        PlayVoiceGreeting("Audio/Greetings.wav");
        DisplayAsciiArt();

        userName = GetUserName();
        GreetUser(userName);
        InitializeResponses(); // new: load keyword responses
        ChatLoop();
    }

    static void PlayVoiceGreeting(string audioFilePath)
    {
        try
        {
            SoundPlayer player = new SoundPlayer(audioFilePath);
            player.PlaySync();
        }
        catch
        {
            Console.WriteLine("Could not play the audio greeting.");
        }
    }

    static void DisplayAsciiArt()
    {
        DisplayCybersecurityLogo();
    }

    public static void DisplayCybersecurityLogo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        string[] logoLines = {
            "  ██████╗  █████╗ ███╗    ██╗███████╗",
            "  ██╔══██╗██╔══██╗████╗  ██║██╔════╝",
            "  ██████╔╝███████║██╔██╗ ██║███████╗",
            "  ██╔══██╗██╔══██║██║╚██╗██║╚════██║",
            "  ██████╔╝██║  ██║██║ ╚████║███████║",
            "  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝",
            "  Cybersecurity Awareness Bot"
        };

        foreach (string line in logoLines)
        {
            int padding = Console.WindowWidth - line.Length;
            if (padding < 0) padding = 0;
            Console.WriteLine(new string(' ', padding) + line);
        }

        Console.ResetColor();
    }

    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static void GreetUser(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWelcome, {name}! I'm the Cybersecurity Awareness Bot. How can I help you today?");
        Console.ResetColor();
    }

    static void ChatLoop()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();

            string userInput = Console.ReadLine().ToLower();

            if (userInput == "exit" || userInput == "quit")
                break;

            string response = GenerateResponse(userInput);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Bot: {response}");
            Console.ResetColor();
        }
    }

    // NEW: Initialize keyword response bank
    static void InitializeResponses()
    {
        keywordResponses["password"] = new List<string>
        {
            "Use strong and unique passwords for every site.",
            "Avoid personal info in passwords. Try passphrases.",
            "Use a password manager to store and generate secure passwords."
        };

        keywordResponses["phishing"] = new List<string>
        {
            "Don’t click suspicious links or attachments.",
            "Check email addresses closely; phishing emails often impersonate real ones.",
            "If unsure, contact the sender directly via trusted methods."
        };

        keywordResponses["privacy"] = new List<string>
        {
            "Limit what personal info you share online.",
            "Review privacy settings on social media and browsers regularly.",
            "Use encrypted communication tools to protect your data."
        };
    }

    static string GenerateResponse(string input)
    {
        string sentiment = DetectSentiment(input);
        string response = "";

        if (input.Contains("name is "))
        {
            userName = input.Substring(input.IndexOf("name is ") + 8);
            return $"Nice to meet you, {userName}!";
        }

        if (input.Contains("interested in"))
        {
            userInterest = input.Substring(input.IndexOf("interested in") + 13).Trim();
            return $"Great! I'll remember that you're interested in {userInterest}. It's a crucial part of staying safe online.";
        }

        if (!string.IsNullOrEmpty(userInterest) && input.Contains("remind me"))
        {
            return $"As someone interested in {userInterest}, remember to regularly update your privacy settings and use secure connections.";
        }

        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                var rand = new Random();
                string tip = keywordResponses[keyword][rand.Next(keywordResponses[keyword].Count)];

                // Add sentiment touch
                if (!string.IsNullOrEmpty(sentiment))
                    response += $"{sentiment} ";

                response += tip;
                return response;
            }
        }

        if (!string.IsNullOrEmpty(sentiment))
        {
            return $"{sentiment} I’m here to help with anything cybersecurity related.";
        }

        return "I'm not sure I understand. Could you rephrase or ask about topics like phishing, passwords, or privacy?";
    }

    // NEW: Sentiment detection
    static string DetectSentiment(string input)
    {
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous"))
            return "It's completely normal to feel concerned. ";
        else if (input.Contains("curious") || input.Contains("interested"))
            return "I love your curiosity! ";
        else if (input.Contains("frustrated") || input.Contains("angry"))
            return "I'm sorry you're feeling that way. ";
        else
            return "";
    }
}
