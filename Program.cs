//  Jonathan Bodrero
//  Lab 6 Piglatin Encoder
//  June 26 - .., 2025


Console.Clear();        //  Clear and greeting / instructions.
Console.Write("Welcome to the PigLatin encoder.  \nPlease enter your message to encrypt: ");

string originalMessage = Console.ReadLine();
//Console.WriteLine(originalMessage);     //  Verify message entered correctly.
string originalMessageLower = originalMessage.ToLower();    //  Turn all to lower case at front.
string[] messageWords = originalMessageLower.Split(' '); // This should split message into lower case words.

string pigLatinMessage = "";        //  The final PL message
string shiftedMessage = "";         //  The final encoded message
Random random = new Random();
int shift = random.Next(1, 26);     //  Random shift for message


for (int i = 0; i < messageWords.Length - 1; i++)       // Check each word in the message up to last word.
{
    string givenWord = messageWords[i];     //  Get ith word from message
    char letterToAnalyze = 'z';
    int location = 0;


    for (int j = 0; j < givenWord.Length; j++)  //  Analyze a word in the message.
    {
        letterToAnalyze = givenWord[j];         //  Get each letter

        if (IsVowel(letterToAnalyze))           //  Find location of first vowel.
        {
            location = j;
            break;
        }
    }

    pigLatinMessage = pigLatinMessage + " " + PigLatinWord(givenWord, location);  //  PigLatin the word and add to message.

}
//  Check for punctuation at end of message
string lastWord = messageWords[messageWords.Length - 1];
if (HasPunctuation(lastWord))       //  Does the word end in punctuation?
{
    int location = 0;
    char letterToAnalyze;
    char lastChar = lastWord[lastWord.Length - 1];
    string tempWord = lastWord.Trim(lastChar);
    for (int j = 0; j < tempWord.Length; j++)  //  Analyze a word in the message.
    {
        letterToAnalyze = tempWord[j];         //  Get each letter

        if (IsVowel(letterToAnalyze))           //  Check if letter is vowel
        {
            location = j;
            break;
        }
    }

    pigLatinMessage = pigLatinMessage + " " + PigLatinWord(tempWord, location) + lastChar; 
}
else                                            //  If word does not end in punctuation.
{
    int location = 0;
    for (int j = 0; j < lastWord.Length; j++)  //  Analyze a word in the message.
    {
        char letterToAnalyze = lastWord[j];         //  Get each letter


        if (IsVowel(letterToAnalyze))           //  Check if letter is vowel
        {
            location = j;
            break;
        }
    }

    pigLatinMessage = pigLatinMessage + " " + PigLatinWord(lastWord, location);     //  Add word to PL message.

}

for (int i = 0; i < pigLatinMessage.Length - 1; i++)        //  Shift each letter before last character in message.
{
    char x = pigLatinMessage[i];
    char y = ShiftChar(x, shift);
    shiftedMessage = shiftedMessage + y;
}

char lastCharPunctuation = pigLatinMessage[pigLatinMessage.Length - 1];     //  Handle last char as punctuation (or not).
if (lastCharPunctuation == '.' || lastCharPunctuation == '?' || lastCharPunctuation == ',' || lastCharPunctuation == ';' || lastCharPunctuation == '!')
{
    shiftedMessage = shiftedMessage + lastCharPunctuation;
}
else        //  If not punctuation, add to message.
{
    shiftedMessage = shiftedMessage + ShiftChar(lastCharPunctuation, shift);
}


Console.WriteLine($"In Pig Latin, your message is: {pigLatinMessage}");        //  Write PigLatin message
Console.WriteLine($"Encrypted with a shift of {shift} we get: {shiftedMessage}"); // Write shifted message.


bool IsVowel(char x)        //  Check if character is a vowel
{
    bool isVowelM = false;
    if (x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u' || x == 'y')
    {
        isVowelM = true;
    }
    else
    { isVowelM = false; }
    return isVowelM;
}


string PigLatinWord(string givenWord, int location)     //  Translate word to PigLatin given location of first vowel.
{
    string pigLatinWord = "";       //  If starts with a vowel, add "way"
    if (location == 0)
    {
        pigLatinWord = givenWord + "way";
        return pigLatinWord;
    }
    else                            //  If doesn't start with a vowel, find first vowel and translate.
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

bool HasPunctuation(string givenWord)       //  Does word have punctuation?
{
    bool hasPunct = false;
    char lastChar = givenWord[givenWord.Length - 1];
    if (lastChar == '.' || lastChar == '?' || lastChar == ',' || lastChar == ';' || lastChar == '!')
    {
        hasPunct = true;
    }
    return hasPunct;
}



char ShiftChar(char c, int shift)       //  Encode a letter with given shift
{
    int charNum;
    int charNumShift;
    char charFinal;
    if (c != ' ')
    {
        charNum = (int)c;
        charNumShift = charNum + shift;
        if (charNumShift <= 122)
        { charFinal = (char)charNumShift; }
        else
        {
            charFinal = (char) (charNumShift-26);
        }
        ;
        return charFinal;
    }
    return c;

}
