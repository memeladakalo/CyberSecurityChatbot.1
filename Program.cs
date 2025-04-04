using System;
using System.Collections.Generic;
using System.Media;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Initializing Cybersecurity Chatbot...\n");
            Console.ResetColor();

            // Task 1: Play a voice greeting
            PlayVoiceGreeting("greeting..wav");

            // Task 2: Display ASCII Art
            DisplayAsciiArt();

            // Task 3: Ask for User’s Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("What is your name? ");
            Console.ResetColor();
            string userName = Console.ReadLine().Trim();

            GreetUser(userName);

            // Task 4: Start Chatbot
            StartChatbot(userName);
        }

        // Task 1: Play voice greeting
        static void PlayVoiceGreeting(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists("greeting..wav"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Audio file not found at {filePath}");
                    Console.ResetColor();
                    return;
                }

                using (SoundPlayer player = new SoundPlayer("greeting..wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error playing sound: " + ex.Message);
                Console.ResetColor();
            }
        }

        // Task 2: Display ASCII art
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string asciiArt = @"
            ██╗     ██╗███████╗ █████╗ ██╗  ██╗
            ██║     ██║██╔════╝██╔══██╗██║  ██║
            ██║     ██║███████╗███████║███████║
            ██║     ██║╚════██║██╔══██║██╔══██║
            ███████╗██║███████║██║  ██║██║  ██║
            ╚══════╝╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝ 
            WELCOME TO LIZAH Chatbot! 
            ";
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        // Task 3: Greet the user
        static void GreetUser(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Chatbot.");
            Console.ResetColor();
        }

        // Task 4: Start chatbot conversation
        static void StartChatbot(string userName)
        {
            // Dictionary for predefined responses
            Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "how are you?", "I'm just a bot, but I'm here to help you stay safe online!" },
                { "what's your purpose?", "I educate users about Cybersecurity threats and how to stay safe." },
                { "what can I ask you about?", "You can ask me about phishing, password safety, and safe browsing." },
                { "tell me about phishing", "Phishing is a scam where attackers trick you into revealing personal information." },
                { "yes, tell me about password safety", "Use strong passwords with a mix of letters, numbers, and symbols." },
                { "safe browsing", "Avoid clicking on suspicious links and use trusted websites only." }
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYou can ask me cybersecurity-related questions or type 'exit' to leave.");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Chatbot: Goodbye! Stay safe online!");
                    Console.ResetColor();
                    break;
                }
                else if (responses.ContainsKey(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Chatbot: {responses[userInput]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: I didn't quite get that. Try asking about cybersecurity topics!");
                    Console.ResetColor();
                }
            }
        }
    }
}
