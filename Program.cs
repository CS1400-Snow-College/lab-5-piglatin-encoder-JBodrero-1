//  Jonathan Bodrero
//  Lab 6 Piglatin Encoder
//  June 26 - .., 2025


Console.Clear();
Console.Write("Welcome to the PigLatin encoder.  \nPlease enter your message to encrypt: ");

string originalMessage = Console.ReadLine();
Console.WriteLine(originalMessage);     //  Verify message intered correctly.

string[] messageWords = originalMessage.Split(' '); // This should split message into words.




