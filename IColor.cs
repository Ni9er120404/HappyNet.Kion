namespace HappyNet.Kion
{
    public interface IColor
    {
        /// <summary>
        /// Converts HSV values to your color scheme
        /// </summary>
        /// <param name="h">Hue</param>
        /// <param name="s">Saturation</param>
        /// <param name="v">Value (brightness)</param>
        /// <returns>Your color scheme</returns>
        abstract static IColor FromHSV(float h, float s, float v);

        /// <summary>
        /// Converts RGB values to your color scheme
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <returns>Your color scheme</returns>
        abstract static IColor FromRGB(byte r, byte g, byte b);

        /// <summary>
        /// Performs convertion to requested color type
        /// </summary>
        /// <typeparam name="T">Needed color scheme</typeparam>
        /// <param name="color">Some color scheme</param>
        /// <returns>Typed color scheme</returns>
        /// <exception cref="NotImplementedException">No proper implementation for your color scheme</exception>
        static T FromColor<T>(IColor color) where T : IColor
        {
            if (color is T copy)
                return copy;
            else if (color is Hsv hsv)
                return (T)T.FromHSV(hsv.H, hsv.S, hsv.V);
            else if (color is Rgb rgb)
                return (T)T.FromRGB(rgb.R, rgb.G, rgb.B);
            else throw new NotImplementedException("Have no converter for this color scheme");
        }
    }
}
