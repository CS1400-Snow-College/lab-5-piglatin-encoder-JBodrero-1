//  Jonathan Bodrero
//  Lab 6 Piglatin Encoder
//  June 26 - .., 2025


Console.Clear();
Console.Write("Welcome to the PigLatin encoder.  \nPlease enter your message to encrypt: ");

string originalMessage = Console.ReadLine();
Console.WriteLine(originalMessage);     //  Verify message intered correctly.

string[] messageWords = originalMessage.Split(' '); // This should split message into words.

string pigLatinMessage = "";

/*Console.WriteLine("Your message was: ");      //  Debugging code.
foreach (string word in messageWords)
{
    Console.WriteLine(word);
}*/

for (int i = 0; i < messageWords.Length; i++)       // Check each word in the message.
{
    string givenWord = messageWords[i];
    string pigLatinWord = "";
    bool isVowel = false;
    char letterToAnalyze = 'z';
    int location = 0;




    for (int j = 0; j < givenWord.Length; j++)  //  Analyze a word in the message.
    {
        string wordTempConsonant = givenWord.ToLower();  //  Convert word to lowercase for easier analysis.
        letterToAnalyze = wordTempConsonant[j];         //  Get each letter

        if (IsVowel(letterToAnalyze))           //  Check if letter is vowel
        {
            location = j;
            break;
        }
    }
        
    pigLatinMessage = pigLatinMessage + " " + PigLatinWord(givenWord,  location);
    
}
Console.WriteLine(pigLatinMessage);

bool IsVowel(char x)
{
    bool isVowelM = false;
    if (x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u')
    {
        isVowelM = true;
    }
    else
    { isVowelM = false; }
    return isVowelM;
}


string PigLatinWord(string givenWord, int location)
{
    string pigLatinWord = "";
    if (location == 0)
    {
        pigLatinWord = givenWord + "way";
        return pigLatinWord;
    }
    else
    {
        for (int k = location; k < givenWord.Length; k++)
        {
            pigLatinWord = pigLatinWord + givenWord[k];
        }
        for (int m = 0; m < location; m++)
        {
            pigLatinWord = pigLatinWord + givenWord[m];
        }
        pigLatinWord = pigLatinWord + "ay";
        return pigLatinWord;
    }
}

