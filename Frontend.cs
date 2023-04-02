using PasswordGenerator;

Console.WriteLine("Welcome to the Password Generator!");

Console.Write("Enter desired password length: ");
var passwordLength = int.Parse(Console.ReadLine());

Console.Write("Include lowercase letters? (y/n): ");
var includeLowercase = Console.ReadLine().ToLower() == "y";

Console.Write("Include uppercase letters? (y/n): ");
var includeUppercase = Console.ReadLine().ToLower() == "y";

Console.Write("Include numbers? (y/n): ");
var includeNumbers = Console.ReadLine().ToLower() == "y";

Console.Write("Include symbols? (y/n): ");
var includeSymbols = Console.ReadLine().ToLower() == "y";

var password = new Password(includeLowercase, includeUppercase, includeNumbers, includeSymbols);
var generatedPassword = password.Generate(passwordLength);

Console.WriteLine($"Your generated password is: {generatedPassword}");
Console.WriteLine("Press any key to exit.");
Console.ReadKey();
