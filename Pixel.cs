namespace HappyNet.Kion
{
    public readonly struct Pixel
    {
        public readonly IColor Color { get; }

        internal Pixel(IColor color)
        {
            Color = color;
        }
    }
}
