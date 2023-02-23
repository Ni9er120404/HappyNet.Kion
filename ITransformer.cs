namespace HappyNet.Kion
{
    public interface ITransformer
    {
        /// <summary>
        /// Transforms Pixel stream in some way
        /// </summary>
        /// <param name="stream">Unmodified stream</param>
        /// <returns>Transformed stream</returns>
        IEnumerable<Pixel> Transform(IEnumerable<Pixel> stream);
    }
}
