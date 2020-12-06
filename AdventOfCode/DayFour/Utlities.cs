using System.Collections.Generic;
using System.Linq;
using DayFour.Parsing;

namespace DayFour
{
    public static class Utlities
    {
        private static TokenType[] RequiredTokens =
        {
            TokenType.BirthYear, TokenType.ExpirationYear, TokenType.EyeColor,
            TokenType.HairColor, TokenType.IssueYear, TokenType.PassportID, TokenType.Height, TokenType.CountryID
        };

        private static TokenType[] MinimumRequiredTokens = RequiredTokens[..^1];
        public static bool IsValidPassport(IEnumerable<TokenType> tokens)
        {
            if (tokens.Count() < 7) return false;
            var ordered = tokens.OrderBy(token => token);
            return ordered.SequenceEqual(MinimumRequiredTokens.OrderBy(token => token)) ||
                   ordered.SequenceEqual(RequiredTokens.OrderBy(token => token));
        }
    }
}