namespace CodingChallenge.Models
{
    public interface IColorCode
    {
        string Name { get; set; }

        FourBandValues FourBand { get; set; }
    }
}