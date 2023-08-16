using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();
        string[]? updatedString = input?.Split(' ');

        Dictionary<int, string> hotResponses = new()
        {
            { 1, "sandals" },
            { 2, "sunglasses" },
            { 3, "fail" },
            { 4, "shirt" },
            { 5, "fail" },
            { 6, "shorts" },
            { 7, "leaving house" },
            { 8, "Removing PJs" }
        };

        Dictionary<int, string> coldResponses = new()
        {
            { 1, "boots" },
            { 2, "hat" },
            { 3, "socks" },
            { 4, "shirt" },
            { 5, "jacket" },
            { 6, "pants" },
            { 7, "leaving house" },
            { 8, "Removing PJs" }
        };

        string? temp = updatedString?[0];
        Dictionary<int, string> responses = temp == "HOT" ? hotResponses : coldResponses;
        bool output = CheckRules(updatedString, responses, temp);

        if (output)
        {
            Console.WriteLine("Valid sequence of commands.");
        }
        else
        {
            Console.WriteLine("Invalid sequence of commands.");
        }

        Console.ReadLine();
    }

    static bool CheckRules(string[]? inputCommands, Dictionary<int, string> responses, string? temp)
    {
        bool wearingPajamas = true;
        bool wearingFootwear = false;
        bool wearingHeadwear = false;
        bool wearingShirt = false;
        bool wearingJacket = false;
        bool wearingPants = false;
        bool wearingSocks = false;

        for (int i = 1; i < inputCommands?.Length; i++)
        {
            int commandNumber = int.Parse(inputCommands[i]);
            if (!responses.TryGetValue(commandNumber, out string? val))
            {
                Console.WriteLine("fail");
                return false;
            }

            if (commandNumber == 8)
            {
                if (!wearingPajamas)
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingPajamas = false;
                Console.WriteLine(val);
            }
            else if (wearingPajamas)
            {
                Console.WriteLine("fail");
                return false;
            }
            else if (commandNumber == 1)
            {
                if (wearingFootwear || (temp == "HOT" && wearingSocks))
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingFootwear = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 2)
            {
                if (wearingHeadwear)
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingHeadwear = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 3)
            {
                if (wearingSocks || temp == "HOT")
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingSocks = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 4)
            {
                if (wearingShirt)
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingShirt = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 5)
            {
                if (wearingJacket || temp == "HOT")
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingJacket = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 6)
            {
                if (wearingPants)
                {
                    Console.WriteLine("fail");
                    return false;
                }

                wearingPants = true;
                Console.WriteLine(val);
            }
            else if (commandNumber == 7)
            {
                if (!wearingShirt || !wearingPants ||
                    (!wearingFootwear && !wearingSocks) || (!wearingJacket && temp == "COLD") ||
                    !wearingHeadwear)
                {
                    Console.WriteLine("fail");
                    return false;
                }

                Console.WriteLine(val);
                return true;
            }
        }

        Console.WriteLine("fail");
        return false;
    }


}
