using System;
using TMPro;

// Adds methods to set text without allocating garbage or updating text geometry when it hasn't changed.
namespace Switchboard
{
	public static class TextMeshProExtensions
	{
		private static char[] StaticBuffer => _buffer ??= new char[StringMaker.MaxCapacity];
		[ThreadStatic] // <- If you think these methods could be accessed from multiple threads. (Unlikely, can remove.)
		private static char[] _buffer;

		public static void SetText(this TMP_Text textComponent, StringMaker stringMaker)
		{
			SetText(textComponent, stringMaker, null);
		}

		public static void SetText(this TMP_Text textComponent, StringMaker stringMaker, char[] buffer)
		{
			if(textComponent == null)
				throw new ArgumentNullException(nameof(textComponent));

			if(stringMaker == null)
				throw new ArgumentNullException(nameof(stringMaker));

			buffer ??= StaticBuffer;

			if(buffer.Length < stringMaker.Length)
				throw new ArgumentException($"The {nameof(buffer)} is not long enough.", nameof(buffer));

			if(!stringMaker.Equals(textComponent.text))
			{
				stringMaker.CopyTo(new Span<char>(buffer));
				textComponent.SetCharArray(buffer, 0, stringMaker.Length);
			}
		}
	}
}