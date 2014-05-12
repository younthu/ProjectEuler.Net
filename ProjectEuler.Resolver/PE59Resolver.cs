using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace ProjectEuler.Resolver
{
    [TestClass]
    public class PE59Resolver
    {
        private string GetEncryptedText() {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ProjectEuler.Resolver.cipher1.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }

        }
        private bool IsPrintableCharacter(char candidate)
        {
            return !(candidate < 0x20 || candidate >= 127);
        }
        [TestMethod]
        public void TestMethod1()
        {

            string[] chars = GetEncryptedText().Split(new char[]{','});
            List<char> encryptedChars = new List<char>();
            foreach (string c in chars)
            {
                encryptedChars.Add(Convert.ToChar(Convert.ToByte(c)));
            }

            List<char> candidates1 = new List<char>();
            List<char> candidates2 = new List<char>();
            List<char> candidates3 = new List<char>();

            for (char i = 'a'; i <='z'; i++)
            {
                candidates1.Add(i);
                candidates2.Add(i);
                candidates3.Add(i);
            }

            for (int i = 0; i < encryptedChars.Count; i+=3)
            {
                char encryptedChar = encryptedChars[i];
                for (int j = candidates1.Count - 1 ; j >= 0; j--)
                {
                    char key = candidates1[j];
                    char plainChar = (char)(encryptedChar ^ key);

                    if (!IsPrintableCharacter(plainChar))
                    {
                        candidates1.RemoveAt(j);
                    }
                }

                if (i + 1 >= encryptedChars.Count)
                {
                    continue;
                }
                encryptedChar = encryptedChars[i + 1];
                for (int j = candidates2.Count - 1; j >= 0; j--)
                {
                    char key = candidates2[j];
                    char plainChar = (char)(encryptedChar ^ key);

                    if (!IsPrintableCharacter(plainChar))
                    {
                        candidates2.RemoveAt(j);
                    }
                }

                if (i + 2 >= encryptedChars.Count)
                {
                    continue;
                }
                 encryptedChar = encryptedChars[i + 2];
                for (int j = candidates3.Count - 1; j >= 0; j--)
                {
                    char key = candidates3[j];
                    char plainChar = (char)(encryptedChar ^ key);

                    if (!IsPrintableCharacter(plainChar))
                    {
                        candidates3.RemoveAt(j);
                    }
                }
            }

            // print candidates
            Console.WriteLine("{0},{1},{2}",candidates1.Count, candidates2.Count, candidates3.Count);
            List<string> allLines = new List<string>();

            foreach (var key1 in candidates1)
            {
                foreach (var key2 in candidates2)
                {
                    foreach (var key3 in candidates3)
                    {
                        string result = "";
                        for (int i = 0; i < encryptedChars.Count; i += 3)
                        {
                            result += (char)(key1 ^ encryptedChars[i]);

                            if (i + 1 >= encryptedChars.Count)
                            {
                                continue;
                            }
                            result += (char)(key2  ^ encryptedChars[i + 1]);

                            if (i + 2 >= encryptedChars.Count)
                            {
                                continue;
                            }

                            result += (char)(key3 ^ encryptedChars[i + 2]);
                            
                        }

                        string outStr = string.Format("{0},{1},{2}:{3}", key1,key2,key3,result);
                        allLines.Add(outStr);
                       
                        
                    }
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\Andrew\WriteLines.txt", allLines);
            throw new NotImplementedException(" This is not resolved");
        }
    }
}
