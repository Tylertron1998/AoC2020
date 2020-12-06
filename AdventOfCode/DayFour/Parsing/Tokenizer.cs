using System;
using System.Collections.Generic;
using System.Text;

namespace DayFour.Parsing
{
    public class Tokenizer
    {
        public TokenCollection[] GetTokens(string[] inputs)
        {

            var collections = new List<TokenCollection>();

            var collection = default(TokenCollection);

            var tokens = new List<Token>();
            
            for (var index = 0; index < inputs.Length; index++)
            {
                var input = inputs[index];

                if (string.IsNullOrWhiteSpace(input))
                {
                    collection.Tokens = tokens.ToArray();
                    collections.Add(collection);
                    collection = default;
                    tokens = new List<Token>();
                    continue;
                }

                var split = input.Split(' ');

                foreach (var individualToken in split)
                {
                    var token = default(Token);
                    var i = individualToken.IndexOf(':');

                    if (i == -1)
                    {
                        throw new ArgumentException(
                            $"{nameof(individualToken)} had no ':' seperator; value was: '{individualToken}'");
                    }

                    var lhs = individualToken[..i];
                    var rhs = individualToken[(i + 1)..];
                    
                    token.RawValue = rhs;

                    token.Type = lhs switch
                    {
                        "byr" => TokenType.BirthYear,
                        "iyr" => TokenType.IssueYear,
                        "eyr" => TokenType.ExpirationYear,
                        "hgt" => TokenType.Height,
                        "hcl" => TokenType.HairColor,
                        "ecl" => TokenType.EyeColor,
                        "pid" => TokenType.PassportID,
                        "cid" => TokenType.CountryID,
                        _ => throw new ArgumentException($"{nameof(lhs)} was unexpected value; got: {lhs}")
                    };

                    tokens.Add(token);
                }
            }

            collection.Tokens = tokens.ToArray();
            collections.Add(collection);

            return collections.ToArray();
        }
    }
}