namespace HappyNet.Kion
{
	public readonly struct Rgb : IColor
	{
		/// <summary>
		/// Gets the red component.
		/// </summary>
		public readonly byte R { get; }

		/// <summary>
		/// Gets the green component.
		/// </summary>
		public readonly byte G { get; }

		/// <summary>
		/// Gets the blue component.
		/// </summary>
		public readonly byte B { get; }

		private Rgb(byte r, byte g, byte b)
		{
			R = r;
			G = g;
			B = b;
		}

		public static IColor FromHSV(float h, float s, float v)
		{
			h = Math.Clamp(h, 0, 360);
			s = Math.Clamp(s, 0, 1);
			v = Math.Clamp(v, 0, 1);

			float chroma = v * s;

			byte hd = (byte)(h / 60);
			float x = chroma * (1 - Math.Abs((hd % 2) - 1));
			(float r1, float g1, float b1) = hd switch
			{
				>= 0 and < 1 => (chroma, x, 0f),
				>= 1 and < 2 => (x, chroma, 0f),
				>= 2 and < 3 => (0f, chroma, x),
				>= 3 and < 4 => (0f, x, chroma),
				>= 4 and < 5 => (x, 0f, chroma),
				>= 5 and < 6 => (chroma, 0f, x),
				_ => (0f, 0f, 0f)
			};

			float m = v - chroma;
			(float r, float g, float b) = ((r1 + m) * 255, (g1 + m) * 255, (b1 + m) * 255);
			return new Rgb((byte)r, (byte)g, (byte)b);
		}

		public static IColor FromRGB(byte r, byte g, byte b)
		{
			return new Rgb(r, g, b);
		}
	}
}
