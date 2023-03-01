namespace HappyNet.Kion
{
	/// <summary>
	/// Performs brightness transformations on pixel streams
	/// </summary>
	public class Brightness : ITransformer
	{
		private readonly float _multiplayer;

		public Brightness() { }

		public Brightness(float multiplayer)
		{
			_multiplayer = multiplayer;
		}

		public IEnumerable<Pixel> Transform(IEnumerable<Pixel> stream)
		{
			foreach (Pixel pixel in stream)
			{
				Hsv hsv = IColor.FromColor<Hsv>(pixel.Color);

				float v = hsv.V;

				v += _multiplayer;

				yield return new Pixel(Hsv.FromHSV(hsv.H, hsv.S, v));
			}
		}
	}
}