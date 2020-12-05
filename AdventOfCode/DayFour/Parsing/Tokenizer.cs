using System;
using System.Collections.Generic;
using System.Text;
using DayFour.Objects;

namespace DayFour
{
    public class Tokenizer
    {
        public TokenCollection[] GetTokens(string[] inputs)
        {

            var collections = new List<TokenCollection>();

            var collection = default(TokenCollection);
            var sb = new StringBuilder();
            
            var tokens = new List<Token>();
            
            for (var index = 0; index < inputs.Length; index++)
            {
                var input = inputs[index];
                sb.AppendLine(input);

                if (string.IsNullOrWhiteSpace(input))
                {
                    collection.Tokens = tokens.ToArray();
                    collections.Add(collection);
                    collection = default;
                    sb = new StringBuilder();
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

                    switch (lhs)
                    {
                        case "byr":
                        {
                            token.Type = TokenType.BirthYear;
                            break;
                        }
                        case "iyr":
                        {
                            token.Type = TokenType.IssueYear;
                            break;
                        }
                        case "eyr":
                        {
                            token.Type = TokenType.ExpirationYear;
                            break;
                        }
                        case "hgt":
                        {
                            token.Type = TokenType.Height;
                            break;
                        }
                        case "hcl":
                        {
                            token.Type = TokenType.HairColor;
                            break;
                        }
                        case "ecl":
                        {
                            token.Type = TokenType.EyeColor;
                            break;
                        }
                        case "pid":
                        {
                            token.Type = TokenType.PassportID;
                            break;
                        }
                        case "cid":
                        {
                            token.Type = TokenType.CountryID;
                            break;
                        }
                        default: throw new ArgumentException($"{nameof(lhs)} was unexpected value; got: {lhs}");
                    }
                    
                    tokens.Add(token);
                }
                collection.RawValue = sb.ToString();
            }

            collection.Tokens = tokens.ToArray();
            collections.Add(collection);

            return collections.ToArray();
        }
    }
}