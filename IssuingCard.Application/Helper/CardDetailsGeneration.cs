namespace IssuingCard.Application.Helper;

public class CardDetailsGeneration
{
    public static string GenerateCardNumber()
    {
        long CardNumber = Random.Shared.NextInt64(1000000000000000L, 9999999999999999L);
        
        return CardNumber.ToString();
    }

    public static string GenerateCvc()
    {
        return Random.Shared.Next(100, 1000).ToString();
    }
}