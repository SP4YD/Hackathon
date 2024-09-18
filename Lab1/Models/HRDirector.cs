namespace Lab1.Models;

public class HRDirector
{
    private HRManager manager = null;
    private int countConductedHack = 0;
    private double harmonicSum = 0;

    public HRDirector(HRManager newManager)
    {
        manager = newManager;
    }

    public double CalculationHarm(List<Junior> juns, List<TeamLead> tls, int[] matches)
    {
        double sumOfInverses = 0;
        int n = matches.Length;

        foreach (var pair in matches.Select((junId, tlId) => new { junId, tlId }))
        {
            double satisfactionJunior = 20 - Array.IndexOf(juns[pair.junId].WishListTL, pair.tlId);;
            double satisfactionTeamLead = 20 - Array.IndexOf(tls[pair.tlId].WishListJun, pair.junId);
            
            sumOfInverses += 1.0 / satisfactionJunior;
            sumOfInverses += 1.0 / satisfactionTeamLead;
        }

        double result = 2 * n / sumOfInverses;
        harmonicSum += result;
        countConductedHack++;
        
        return result;
    }
    
    public double HarmonicMean
    {
        get => harmonicSum / countConductedHack;
    }
}