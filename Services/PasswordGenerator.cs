using System.Text;
using DemoDotnetWebApi.Interfaces;

namespace DemoDotnetWebApi.Services;

public class PasswordGenerator : IPasswordGenerator
{
    private readonly int passwordLength;
    private readonly IRandomCharacterGenerator randomCharacterGenerator;
    private readonly IStringShuffler stringShuffler;

    public PasswordGenerator(IRandomCharacterGenerator randomCharacterGenerator, IStringShuffler stringShuffler)
    {
        this.passwordLength = 16;
        this.randomCharacterGenerator = randomCharacterGenerator;
        this.stringShuffler = stringShuffler;
    }

    /// <summary>
    /// Generate random password
    /// Generated password length is 16
    /// Generated password contains at least one uppercase character
    /// Generated password contains at least one lowercase character
    /// Generated password contains at least one digit character
    /// Generated password contains at least one special character
    /// </summary>
    /// <returns>Generated password</returns>
    public String Generate()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(randomCharacterGenerator.GenerateUppercaseCharacter());
        stringBuilder.Append(randomCharacterGenerator.GenerateLowercaseCharacter());
        stringBuilder.Append(randomCharacterGenerator.GenerateDigitCharacter());
        stringBuilder.Append(randomCharacterGenerator.GenerateSpecialCharacter());

        for (int i = 0; i < passwordLength - 4; i++)
        {
            stringBuilder.Append(randomCharacterGenerator.GenerateAllowedCharacter());
        }

        return stringShuffler.Shuffle(stringBuilder.ToString());
    }
}
