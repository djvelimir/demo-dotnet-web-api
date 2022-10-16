using System.Text;
using demo_dotnet_web_api.Interfaces;

namespace demo_dotnet_web_api.Services;

public class PasswordGenerator : IPasswordGenerator
{
    private static readonly int PASSWORD_LENGTH = 16;
    private static readonly String UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly String LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
    private static readonly String DIGIT_CHARACTERS = "0123456789";
    private static readonly String SPECIAL_CHARACTERS = "~`!@#$%^&*()-_=+[{]}\\|;:\'\",<.>/?";
    private static readonly String UNION_OF_ALLOWED_CHARACTERS = UPPERCASE_CHARACTERS +
            LOWERCASE_CHARACTERS +
            DIGIT_CHARACTERS +
            SPECIAL_CHARACTERS;
    private static readonly Random random = new Random();

    /**
     * Generate random password
     * Generated password length is 16
     * Generated password contains at least one uppercase character
     * Generated password contains at least one lowercase character
     * Generated password contains at least one digit character
     * Generated password contains at least one special character
     *
     * @return generated password
     */
    public String Generate()
    {
        var stringBuilder = new StringBuilder();

        // generate at least one uppercase character
        stringBuilder.Append(GenerateRandomCharacter(UPPERCASE_CHARACTERS));

        // generate at least one lowercase character
        stringBuilder.Append(GenerateRandomCharacter(LOWERCASE_CHARACTERS));

        // generate at least one digit character
        stringBuilder.Append(GenerateRandomCharacter(DIGIT_CHARACTERS));

        // generate at least one special character
        stringBuilder.Append(GenerateRandomCharacter(SPECIAL_CHARACTERS));

        for (int i = 4; i < PASSWORD_LENGTH; i++)
        {
            // generate random character from union of allowed characters
            stringBuilder.Append(GenerateRandomCharacter(UNION_OF_ALLOWED_CHARACTERS));
        }

        // shuffle generated characters
        IList<String> ch = stringBuilder.ToString().Split("").ToList();
        ch.Shuffle();

        // return generated password
        return string.Join("", ch);
    }

    private char GenerateRandomCharacter(String characters)
    {
        return characters.ElementAt(random.Next(characters.Length));
    }
}