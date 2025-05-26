using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CybersecurityChatBot_ST10444488
{
    class Program
    {
        static void Main()
        {
            //play audio greeting
            PlayGreetingAudio("cyberbotvoice.wav");

            Console.Title = "Cybersecurity Awareness chatbot";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string('=',Console.WindowWidth));// Top border
            Console.WriteLine(@"
   ______      __                                        _ __             
  / ____/_  __/ /_  ___  _____________  _______  _______(_) /___  __      
 / /   / / / / __ \/ _ \/ ___/ ___/ _ \/ ___/ / / / ___/ / __/ / / /      
/ /___/ /_/ / /_/ /  __/ /  (__  )  __/ /__/ /_/ / /  / / /_/ /_/ /       
\____/\__, /_.___/\___/_/  /____/\___/\___/\__,_/_/  /_/\__/\__, /        
    _/____/                                                /____/      __ 
   /   |_      ______ _________  ____  ___  __________    / __ )____  / /_
  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/   / __  / __ \/ __/
 / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  )   / /_/ / /_/ / /_  
/_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/   /_____/\____/\__/  
");//ascii art 

            Console.WriteLine(new string('=',Console.WindowWidth));// Bottom border
            Console.ForegroundColor = ConsoleColor.Gray;
            DisplayTypingEffect("\nWelcome to your Cybersecurity Awareness Chatbot!");
            DisplayTypingEffect("What is your Name?\n ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            String userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            DisplayTypingEffect($"\nHello {userName}! I am here to help you stay safe online!");
            DisplayTypingEffect("You can ask about password, 2 factor authentication, updates, phishing, virtual private networks, clicking, or type 'exit' to quit. \n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DisplayTypingEffect($"\n{userName}: ");
                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DisplayTypingEffect("Chatbot: please enter a valid question. Enter 'help' if you would like the options again.\n ");
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DisplayTypingEffect("Chatbot: I hope I was informative. See you next time!!");
                    break;
                }

                HandleUserQuery(userInput, userName);

            }
        }

        static void PlayGreetingAudio(string filepath)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filepath); //gets the full path

                if (File.Exists(fullPath))
                {
                    SoundPlayer player = new SoundPlayer(fullPath);
                    player.PlaySync();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Error: '{filepath}' was not found at the specified location.");
                }
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                DisplayTypingEffect($"Error playing audio: {ex.Message}");
            }
        }
        //dictionary for infformation
        static void HandleUserQuery(string input, string userName)
        {
            Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
            {
                {"help", new List<string>{"You can ask about: 'Passwords', '2 Factor Authentication', 'Updates', 'Phishing', 'Virtual Private Networks', 'Clicking'." } },
                {"password", new List<string>{"When setting a password, make sure it is strong (longer than 8 characters) and never use a password twice." } },
                {"2 factor authentication", new List<string>{" 2 Factor Authentication is the code sent to an email/message or uses a fingerprint on a phone, which applies that extra layer of security to the device and/or application." } },
                {"updates", new List<string>{" Make sure your apps and devices are up to date, as there is cybersecurity updates in there." } },
                {"phishing", new List<string>{" Don't open suspicious files/attachments or emails without ensuring that they were sent by a reputable person." } },
                {"virtual private networks", new List<string>{" When you use a VPN, it is harder for hackers to gain access to your device when on an unsafe network. " } },
                {"How are you?", new List<string>{"I am good thank you" } },
                {"clicking",new List<string>{"Avoid clicking on links, sites or adversitements that you don't know." } },
                {"worried", new List<string>{"It's understandable to feel that way. Cybersecurity is important!" } },
                {"frustrated", new List<string>{"I hear you. Cyber threats can be overwhelming. Let’s break it down." } }

        };

            //if (responses.ConstainsKey(input))
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    string line = responses[input];
            //    DisplayTypingEffect("Chatbot: ")
            //}
            string detectedKeyword = responses.Keys.FirstOrDefault(key => input.Contains(key));
            Random random = new Random();

            if (detectedKeyword != null)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                DisplayTypingEffect($"Chatbot: {responses[detectedKeyword][random.Next(responses[detectedKeyword].Count)]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                DisplayTypingEffect($"Chatbot: I'm not sure about that, {userName}. Would you like me to give you tips for cybersecurity based on your knowledge? (yes/no)\n ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                string reply = Console.ReadLine()?.ToLower().Trim();

                if (reply == "yes")
                {
                    securityTips();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DisplayTypingEffect("Chatbot: No worries! Let me know if you have any other cybersecurity questions.");
                }
            }
        }

        static void securityTips()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            DisplayTypingEffect("Chatbot: What level of knowledge do you have of cybersecurity? (beginner/intermediate/up to date)\n ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string level = Console.ReadLine()?.ToLower().Trim();

            Console.ForegroundColor = ConsoleColor.Gray;
            if (level == "beginner")
            {
                DisplayTypingEffect("Chatbot: Cybersecurity is essential in keeping your data safe. For a beginner, make sure that your passwords are secure and strong, and that you don't leave your devices where someone could get onto them.\n");
            }
            else if (level == "intermediate")
            {
                DisplayTypingEffect("Chatbot: Don't just allow sites cookies or app permissions, check before, don't open unknown emails/messages.\n ");
            }
            else if (level == "up to date")
            {
                DisplayTypingEffect("Chatbot: Keep watching out for more cybersecurity tips in the future. Cyber attacks are always there, don't become lenient. \n ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                DisplayTypingEffect("Chatbot: That is not a level: Please enter 'Beginner','Intermediate','Up to date'\n");
            }
        }
        static void DisplayTypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);  // Simulates typing effect
            }
            Console.WriteLine();
        }
    }
}