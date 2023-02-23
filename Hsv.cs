namespace HappyNet.Kion
{
    public readonly struct Hsv : IColor
    {
        /// <summary>
        /// Gets the hue component.
        /// <remarks>A value ranging between 0 and 360.</remarks>
        /// </summary>
        public readonly float H { get; }

        /// <summary>
        /// Gets the saturation component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public readonly float S { get; }

        /// <summary>
        /// Gets the value (brightness) component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public readonly float V { get; }

        private Hsv(float h, float s, float v)
        {
            H = Math.Clamp(h, 0, 360);
            S = Math.Clamp(s, 0, 1);
            V = Math.Clamp(v, 0, 1);
        }

        public static IColor FromHSV(float h, float s, float v)
        {
            return new Hsv(h, s, v);
        }

        public static IColor FromRGB(byte r, byte g, byte b)
        {
            float rd = r / 255f;
            float gd = g / 255f;
            float bd = b / 255f;

            float[] helper = { rd, gd, bd };

            float Cmax = helper.Max();
            float Cmin = helper.Min();
            float delta = Cmax - Cmin;

            float h = 60;
            if (Cmax == rd)
            {
                h *= ((gd - bd) / delta) % 6;
            }
            else if (Cmax == gd)
            {
                h *= (bd - rd) / delta + 2;
            }
            else if (Cmax == bd)
            {
                h *= (rd - gd) / delta + 4;
            }

            float s = Cmax switch
            {
                0 => 0,
                _ => delta / Cmax,
            };

            float v = Cmax;

            return new Hsv(h, s, v);
        }
    }
}
