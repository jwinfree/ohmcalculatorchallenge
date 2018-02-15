namespace CodingChallenge.Models
{
    /// <summary>
    /// Four band values used in Color Codes
    /// </summary>
    public class FourBandValues
    {
        /// <summary>
        /// 1st significant digit
        /// </summary>
        public int FirstPosition { get; set; }

        /// <summary>
        /// 2nd significant digit
        /// </summary>
        public int SecondPosition { get; set; }

        /// <summary>
        /// Multiplier
        /// </summary>
        public int Multiplier { get; set; }

        /// <summary>
        /// Tolerance
        /// </summary>
        public float Tolerance { get; set; }
    }
}