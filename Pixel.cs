namespace HappyNet.Kion
{
    public readonly struct Pixel
    {
        public readonly IColor color;

        internal Pixel(IColor color)
        {
            this.color = color;
        }
    }
}
