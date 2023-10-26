using System.Text;

namespace clients_api
{
    public static class Extensions
    {
        public static string ConvertToDevMagic(this string word)
        {
            word = word.ToLower();
            // Check if the word starts with a vowel
            if (IsVowel(word[0]))
            {
                return word + "yay";
            }
            else
            {
                // Find the index of the first vowel
                int vowelIndex = FindFirstVowelIndex(word);

                if (word[1] == 'y')
                    vowelIndex = 1;
               

                // Move the consonant or consonant cluster to the end and add "ay"
                string devMagicWord = word.Substring(vowelIndex) + word.Substring(0, vowelIndex) + "ay";

                return devMagicWord;
            }
        }



        public static string ConvertToEnglish(this string devMagicWord)
        {
            devMagicWord = devMagicWord.ToLower();

            // Check if the word ends with "yay", "way", or "ay"
            if (devMagicWord.EndsWith("yay"))
            {
                return devMagicWord.Substring(0, devMagicWord.Length - 3);
            }
            else if (devMagicWord.EndsWith("way"))
            {
                return devMagicWord.Substring(0, devMagicWord.Length - 3);
            }
            else if (devMagicWord.EndsWith("ay"))
            {
                // Remove "ay" and move the consonant or consonant cluster to the front
                string englishWord = devMagicWord.Substring(0, devMagicWord.Length - 2);

                // I don't see how to remove the consonant cluster so am only able to handle a single consonant which can be determined
                // so this won't work for a consonant cluster as  how would i know with  atchscr   that scr is the cluster ???
                // basically it seams to me the original consonant cluster's location is lost in the transformation.
                // would need a dictionary of inputted words to map againse perhaps
                int consonantIndex = englishWord.Length - 1;
                return englishWord.Substring(consonantIndex) + englishWord.Substring(0, consonantIndex);
            }
            else
            {
                // Invalid Dev Magic word
                return "Invalid Dev Magic Word";
            }
        }

        private static bool IsVowel(char c)
        {
            char lowerChar = char.ToLower(c);
            return lowerChar == 'a' || lowerChar == 'e' || lowerChar == 'i' || lowerChar == 'o' || lowerChar == 'u';
        }

      

        private static int FindFirstVowelIndex(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    return i;
                }
            }
            // No vowel found, return the length of the word (treat it as all consonants)
            return word.Length;
        }




    }

}



