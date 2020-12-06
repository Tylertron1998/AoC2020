using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayFour.Parsing
{
	public class Parser
	{
		private readonly Regex _hairColorRegex = new("#([0-9|a-z]{6})");

		private readonly Regex _heightRegex = new("(cm|in)", RegexOptions.Compiled);

		public IEnumerable<TokenCollection> Parse(string[] inputs,
			ValidationType validate = ValidationType.ValidatePassport)
		{
			var tokenizer = new Tokenizer();
			var tokenCollections = tokenizer.GetTokens(inputs);

			return validate switch
			{
				ValidationType.ValidatePassportAndValues => ValidatePassportAndValues(tokenCollections),
				ValidationType.ValidatePassport => ValidatePassport(tokenCollections),
				_ => throw new NotSupportedException()
			};
		}

		private IEnumerable<TokenCollection> ValidatePassport(TokenCollection[] tokenCollections)
		{
			return tokenCollections.Where(collection =>
			{
				var tokenTypes = collection.Tokens.Select(token => token.Type);
				return Utlities.IsValidPassport(tokenTypes);
			});
		}

		private IEnumerable<TokenCollection> ValidatePassportAndValues(TokenCollection[] tokenCollections)
		{
			return tokenCollections.Where(collection =>
			{
				var tokens = collection.Tokens;
				var tokenTypes = tokens.Select(token => token.Type);
				var isValidPassport = Utlities.IsValidPassport(tokenTypes);
				return isValidPassport
				       && tokens.All(IsValidToken);
			});
		}

		private bool IsValidToken(Token token)
		{
			return token.Type switch
			{
				TokenType.Height => ValidateHeightToken(token),
				TokenType.BirthYear => ValidateBirthYearToken(token),
				TokenType.ExpirationYear => ValidateExpirationYearToken(token),
				TokenType.EyeColor => ValidateEyeColorToken(token),
				TokenType.HairColor => ValidateHairColorToken(token),
				TokenType.IssueYear => ValidateIssueYearToken(token),
				TokenType.PassportID => ValidatePassportIDToken(token),
				TokenType.CountryID => true,
				_ => false
			};
		}

		private bool ValidatePassportIDToken(Token token)
		{
			var value = token.RawValue;
			return value.Length == 9 && int.TryParse(value, out var _);
		}

		private bool ValidateIssueYearToken(Token token)
		{
			var value = token.RawValue;

			return int.TryParse(value, out var number) && number >= 2010 && number <= 2020;
		}

		private bool ValidateHairColorToken(Token token)
		{
			return _hairColorRegex.IsMatch(token.RawValue);
		}

		private bool ValidateEyeColorToken(Token token)
		{
			return token.RawValue is "amb"
				or "blu" or "brn" or "gry"
				or "grn" or "hzl" or "oth";
		}

		private bool ValidateExpirationYearToken(Token token)
		{
			var value = token.RawValue;

			return int.TryParse(value, out var number) && number >= 2020 && number <= 2030;
		}

		private bool ValidateBirthYearToken(Token token)
		{
			var value = token.RawValue;

			return int.TryParse(value, out var number) && number >= 1920 && number <= 2002;
		}

		private bool ValidateHeightToken(Token token)
		{
			var value = token.RawValue;

			var match = _heightRegex.Match(value);

			if (match.Success)
			{
				var index = match.Index;

				if (!int.TryParse(value[..index], out var number))
				{
					return false;
				}

				return match.Value switch
				{
					"cm" => number >= 150 && number <= 193,
					"in" => number >= 59 && number <= 76,
					_ => false
				};
			}

			return false;
		}
	}
}