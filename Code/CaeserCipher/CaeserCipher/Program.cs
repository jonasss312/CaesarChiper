using System;
using System.Configuration;
using System.IO;

namespace CaeserCipher
{
    internal class Program
    {
        //Filenames
        static string EncodeFile = "Encode.txt";
        static string DecodeFile = "Decode.txt";
        static string EncodeResultFile = "EncodeResult.txt";
        static string DecodeResultFile = "DecodeResult.txt";

        static void Main(string[] args)
        {
            //Initializing Caesar class
            Caesar caesar = new Caesar();

            //Initializing cipher list shift(right) size
            int Step = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Step"));
            //Declaring result string
            string result;

            //Creating data files if they do not exist
            if (!File.Exists(EncodeFile))
                File.Create(EncodeFile).Close();
            if (!File.Exists(DecodeFile))
                File.Create(DecodeFile).Close();

            //Encoding
            if (File.Exists(EncodeFile))
            {
                result = "";
                //Reading encode file Encode.txt
                string[] lines = File.ReadAllLines(EncodeFile);
                //Iterating lines
                foreach (string line in lines)
                {
                    //Encoding each line and adding to result string
                    result += caesar.EncodeDecode(line, Step) + "\n";
                }
                //Writing encoded data to EncodeResult.txt
                File.WriteAllText(EncodeResultFile, result);
            }

            //Decoding
            if (File.Exists(DecodeFile))
            {
                result = "";
                //Reading decode file Decode.txt
                string[] lines = File.ReadAllLines(DecodeFile);
                //Iterating lines
                foreach (string line in lines)
                {
                    //Decoding each line and adding to result string
                    result += caesar.EncodeDecode(line, -Step) + "\n";
                }
                //Writing encoded data to DecodeResult.txt
                File.WriteAllText(DecodeResultFile, result);
            }
        }
    }
}
