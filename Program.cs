using System;
using System.Collections.Generic;
using System.Media;
using System.IO;

public class CybersecurityChatbot
{
    // Dictionaries to store keyword-based short responses and detailed explanations
    static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();
    static Dictionary<string, string> detailedExplanations = new Dictionary<string, string>();

    // Variables to store user information
    static string userName = "";
    static string userInterest = "";

    /// <summary>
    /// The main entry point of the chatbot application.
    /// </summary>
    static void Main(string[] args)
    {
        // Play an audio greeting (if the file exists)
        PlayVoiceGreeting("Audio/Greetings.wav");

        // Display the chatbot's ASCII art logo
        DisplayAsciiArt();

        // Get the user's name
        userName = GetUserName();

        // Greet the user personally
        GreetUser(userName);

        // Initialize the short, keyword-based responses
        InitializeResponses();

        // Initialize the more detailed explanations for specific topics
        InitializeDetailedExplanations();

        // Start the main chat loop
        ChatLoop();
    }

    /// <summary>
    /// Plays an audio file as a greeting.
    /// </summary>
    /// <param name="audioFilePath">The path to the audio file.</param>
    static void PlayVoiceGreeting(string audioFilePath)
    {
        try
        {
            // Creates a SoundPlayer to play WAV files
            SoundPlayer player = new SoundPlayer(audioFilePath);
            // Plays the sound and waits for it to finish
            player.PlaySync();
        }
        catch (Exception ex)
        {
            // Catches any errors during audio playback (e.g., file not found)
            Console.WriteLine($"Could not play the audio greeting. Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays the ASCII art logo for the chatbot.
    /// </summary>
    static void DisplayAsciiArt()
    {
        DisplayCybersecurityLogo();
    }

    /// <summary>
    /// Displays the Cybersecurity Awareness Bot logo in ASCII art.
    /// </summary>
    public static void DisplayCybersecurityLogo()
    {
        Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue

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
            // Calculate padding to center the logo
            int padding = Console.WindowWidth - line.Length;
            if (padding < 0) padding = 2; // Ensure padding is not negative
            Console.WriteLine(new string(' ', padding / 2) + line); // Add padding to center
        }

        Console.ResetColor(); // Reset text color to default
    }

    /// <summary>
    /// Prompts the user to enter their name.
    /// </summary>
    /// <returns>The user's name.</returns>
    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color for input prompt
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.ResetColor();
        return name;
    }

    /// <summary>
    /// Greets the user personally.
    /// </summary>
    /// <param name="name">The name of the user.</param>
    static void GreetUser(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green; // Set text color for greeting
        Console.WriteLine($"\nWelcome, {name}! I'm the Cybersecurity Awareness Bot. How can I help you today?");
        Console.ResetColor();
    }

    /// <summary>
    /// The main loop for interacting with the user.
    /// </summary>
    static void ChatLoop()
    {
        while (true) // Loop indefinitely until the user exits
        {
            Console.ForegroundColor = ConsoleColor.Green; // Set text color for user input prompt
            Console.Write("\nYou: ");
            Console.ResetColor();

            string userInput = Console.ReadLine().ToLower(); // Read user input and convert to lowercase

            // Check if the user wants to exit
            if (userInput == "exit" || userInput == "quit")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Bot: Goodbye! Stay safe online!");
                Console.ResetColor();
                break; // Exit the loop
            }

            // Generate a response based on user input
            string response = GenerateResponse(userInput);
            Console.ForegroundColor = ConsoleColor.Blue; // Set text color for bot's response
            Console.WriteLine($"Bot: {response}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Initializes the dictionary with keyword-based short responses.
    /// </summary>
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
        keywordResponses["Browse"] = new List<string>
        {
            "Always check for 'https://' in website URLs.",
            "Be cautious of pop-ups and unexpected downloads.",
            "Keep your browser and operating system updated."
        };
    }

    /// <summary>
    /// Initializes the dictionary with detailed explanations for specific cybersecurity topics.
    /// </summary>
    static void InitializeDetailedExplanations()
    {
        detailedExplanations["phishing"] =
            "Phishing is a cybercrime where attackers, disguised as trustworthy entities, " +
            "attempt to trick individuals into revealing sensitive information such as " +
            "usernames, passwords, and credit card details. This often happens through " +
            "deceptive emails, messages, or fake websites. \n\n" +
            "Here are some key tips to avoid phishing scams:\n" +
            "1.  Scrutinize Sender Details**: Always double-check the sender's email address. " +
            "Attackers often use slight variations of legitimate addresses (e.g., 'amaz0n.com' instead of 'amazon.com').\n" +
            "2.  Look for Red Flags: Be wary of urgent language, generic greetings (like 'Dear Customer'), " +
            "requests for personal information, and poor grammar or spelling. Legitimate organizations rarely demand " +
            "sensitive data via email.\n" +
            "3.  Hover Before You Click: Before clicking any links, hover your mouse over them " +
            "to see the actual URL. If it doesn't match the sender's apparent domain, it's likely a scam. " +
            "Even better, manually type the known website address into your browser.\n" +
            "4. Verify Requests Independently**: If an email or message asks you to verify account " +
            "information or make a payment, contact the organization directly using a trusted phone number " +
            "or by typing their official website URL into your browser, not by replying to the suspicious message.";

        detailedExplanations["password safety"] =
            "Password safety** is critical for protecting your online accounts and personal data. A strong " +
            "and unique password is your first line of defense against unauthorized access.\n\n" +
            "Follow these principles for **effective password safety:\n" +
            "1.  Complexity: Use a combination of uppercase and lowercase letters, numbers, and symbols. " +
            "Avoid easily guessable information like birthdays, names, or common words.\n" +
            "2.  Length: Aim for passwords that are at least 12-16 characters long. Longer passwords are " +
            "significantly harder and more time-consuming for attackers to crack.\n" +
            "3.  Uniqueness: Never reuse passwords across different online accounts. If one service you use " +
            "suffers a data breach, all other accounts using the same password become immediately vulnerable.\n" +
            "4.  Password Managers**: Consider using a reputable password manager (e.g., LastPass, 1Password, Bitwarden). " +
            "These tools can generate strong, unique passwords for you and securely store them, meaning you only " +
            "need to remember one master password.\n" +
            "5.  Two-Factor Authentication (2FA): Whenever possible, enable 2FA on your accounts. This adds " +
            "an extra layer of security, requiring a second verification step (like a code sent to your phone or " +
            "generated by an authenticator app) in addition to your password. Even if your password is stolen, 2FA " +
            "can prevent unauthorized access.";

        detailedExplanations["safe Browse"] =
            "Safe Browse refers to the practices and technologies that help protect you from " +
            "various online threats like malware, phishing, and unwanted surveillance while you " +
            "are navigating the internet. It's about being vigilant and using the right tools.\n\n" +
            "Here are crucial tips for **safe Browse:\n" +
            "1.  Use HTTPS: Always check that the website URL begins with 'https://' " +
            "and look for a padlock icon in your browser's address bar. This indicates a " +
            "secure, encrypted connection, meaning your data is protected during transit.\n" +
            "2.  Keep Software Updated: Regularly update your web browser, operating " +
            "system, antivirus software, and all other applications. Updates often include critical " +
            "security patches that fix vulnerabilities attackers could exploit.\n" +
            "3.  Be Wary of Downloads: Only download files from trusted and official sources. " +
            "Be extremely cautious with unsolicited downloads or attachments, even if they seem to come " +
            "from someone you know, as their account might be compromised.\n" +
            "4.  Avoid Suspicious Links and Ads**: Don't click on pop-up ads, banners, or links " +
            "from unknown or questionable sources. Many of these can lead to malicious websites, " +
            "trigger unwanted downloads, or attempt to trick you into revealing information.\n" +
            "5.  Use a Reputable Antivirus/Anti-malware Program: Install and keep an up-to-date " +
            "security suite on your computer. This software can detect and remove malicious threats " +
            "before they cause harm.\n" +
            "6.  Public Wi-Fi Caution: Avoid conducting sensitive transactions (like online " +
            "banking or shopping) over public Wi-Fi networks. These networks are often unsecure and " +
            "vulnerable to eavesdropping. If you must use public Wi-Fi, consider using a Virtual Private " +
            "Network (VPN) to encrypt your connection.";
    }

    /// <summary>
    /// Generates a response based on the user's input.
    /// </summary>
    /// <param name="input">The user's input string (in lowercase).</param>
    /// <returns>A string containing the chatbot's response.</returns>
    static string GenerateResponse(string input)
    {
        // Detect the sentiment of the user's input
        string sentiment = DetectSentiment(input);
        string response = "";

        // Check for specific user inputs like stating their name
        if (input.Contains("name is "))
        {
            userName = input.Substring(input.IndexOf("name is ") + 8).Trim();
            return $"Nice to meet you, {userName}!";
        }

        // Check if the user expresses interest in a topic
        if (input.Contains("interested in"))
        {
            userInterest = input.Substring(input.IndexOf("interested in") + 13).Trim();
            return $"Great! I'll remember that you're interested in {userInterest}. It's a crucial part of staying safe online.";
        }

        // Remind the user about their stated interest
        if (!string.IsNullOrEmpty(userInterest) && input.Contains("remind me"))
        {
            return $"As someone interested in {userInterest}, remember to regularly update your privacy settings and use secure connections.";
        }

        // Handle the "tell me more about [topic]" command
        if (input.StartsWith("tell me more about "))
        {
            string topic = input.Replace("tell me more about ", "").Trim();
            // Check if a detailed explanation exists for the requested topic
            if (detailedExplanations.ContainsKey(topic))
            {
                return detailedExplanations[topic];
            }
            else
            {
                // Suggest available topics if the requested one is not found
                return $"I can tell you more about phishing, password safety, and safe Browse. What would you like to know?";
            }
        }

        // Check for keywords to provide short tips
        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                var rand = new Random();
                // Select a random tip from the list for the detected keyword
                string tip = keywordResponses[keyword][rand.Next(keywordResponses[keyword].Count)];

                // Add a sentiment-based phrase if sentiment was detected
                if (!string.IsNullOrEmpty(sentiment))
                    response += $"{sentiment} ";

                response += tip;
                return response;
            }
        }

        // If no specific keyword is matched, respond based on sentiment if available
        if (!string.IsNullOrEmpty(sentiment))
        {
            return $"{sentiment} I’m here to help with anything cybersecurity related.";
        }

        // Default response if no specific intent is understood
        return "I'm not sure I understand. Could you rephrase or ask about topics like phishing, passwords, privacy, or safe Browse? You can also ask 'tell me more about [topic]'.";
    }

    /// <summary>
    /// Detects basic sentiment from the user's input.
    /// </summary>
    /// <param name="input">The user's input string.</param>
    /// <returns>A sentiment-based introductory phrase, or an empty string if no sentiment is detected.</returns>
    static string DetectSentiment(string input)
    {
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous"))
            return "It's completely normal to feel concerned. ";
        else if (input.Contains("curious") || input.Contains("interested"))
            return "I love your curiosity! ";
        else if (input.Contains("frustrated") || input.Contains("angry"))
            return "I'm sorry you're feeling that way. ";
        else
            return ""; // No specific sentiment detected
    }
}