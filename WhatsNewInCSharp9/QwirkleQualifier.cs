namespace WhatsNewInCSharp9
{
	public enum QwirkleQualifier
	{
		Impossible,
		Minimal,
		Decent,
		PrettyGood,
		Qwirkle,
		BeyondExpectations,
		Perfection
	}

	public static class Qwirkle
	{
		public static QwirkleQualifier Qualify(int score) =>
			score switch
			{
				>= 0 and < 4 => QwirkleQualifier.Minimal,
				>= 4 and < 8 => QwirkleQualifier.Decent,
				>= 8 and < 12 => QwirkleQualifier.PrettyGood,
				12 => QwirkleQualifier.Qwirkle,
				> 12 and < 72 => QwirkleQualifier.BeyondExpectations,
				72 => QwirkleQualifier.Perfection,
				_ => QwirkleQualifier.Impossible
			};
	}
}