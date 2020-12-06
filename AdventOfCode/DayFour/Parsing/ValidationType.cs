using System;

namespace DayFour.Parsing
{
	[Flags]
	public enum ValidationType
	{
		ValidatePassport = 1 << 0,
		ValidatePassportAndValues = 1 << 1
	}
}