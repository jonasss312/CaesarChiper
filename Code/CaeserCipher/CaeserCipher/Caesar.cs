using System;
using System.Collections.Generic;
using System.Linq;

namespace CaeserCipher
{
    //A class that encodes and decodes Caeser cipher
    public class Caesar
    {
        private List<string> Ciphers = new List<string>();

        public Caesar()
        {
            //Adding ciphers to list
            InitializeCiphers();
        }

        //Method taht adds ciphers to list
        private void InitializeCiphers()
        {
            //Adding aplhabet letters from A - Z, a - z
            for (char i = 'A'; i <= 'z'; i++)
            {
                Ciphers.Add(Convert.ToString(i));
            }
            //Adding numbers from 0-9 and some common symbols
            for (char i = '!'; i <= '='; i++)
            {
                Ciphers.Add(Convert.ToString(i));
            }
            //Adding a space
            Ciphers.Add(" ");
        }

        //Function that returns encoded/decoded string
        //For encoding: + Step;
        //For decoding: - Step;
        public string EncodeDecode(string input, int Step)
        {
            string result = "";
            //Making Step not exceed cipher list count
            Step = Step % Ciphers.Count();
            //Checking if input was given
            if (input != null)
            {
                //Iterating through every char in input string
                for (int i = 0; i < input.Count(); i++)
                {
                    //Checking if char is in Ciphers list
                    if (!Ciphers.Contains(input[i].ToString()))
                    {
                        //Not encoding
                        result += input[i];
                    }
                    else
                    {
                        //Encoding, changing element from Ciphers list from its position to +/- Step position value
                        int index = ((Ciphers.IndexOf(input[i].ToString()) + Step) + Ciphers.Count()) % Ciphers.Count();
                        //Adding to result string
                        result += Ciphers.ElementAt(index);
                    }
                }
            }
            //Returning encoded string
            return result;
        }
    }
}
