namespace Lab1.Models;
using Lab1.Strategies;

public class HRManager {
    private List<Junior> listJun = null;
    private List<TeamLead> listTL = null;
    private IStrategy curStrategy = new StrategyGS();
    private HRDirector director = null;

    public HRManager(List<Junior> juns, List<TeamLead> TLs)
    {
        listJun = juns;
        listTL = TLs;
        
    }

    public int[] TeamFormation(List<Junior> juns, List<TeamLead> tls)
    {
        int[][] juniorPreferences = new int[juns.Count][];
        int[][] teamLeadPreferences = new int[tls.Count][];

        for (int i = 0; i < juns.Count; i++)
        {
            juniorPreferences[i] = juns[i].WishListTL.ToArray();
        }

        for (int i = 0; i < tls.Count; i++)
        {
            teamLeadPreferences[i] = tls[i].WishListJun.ToArray();
        }

        return curStrategy.Execute(juniorPreferences, teamLeadPreferences);
    }
    
    public HRDirector Director
    {
        get => director;
        set => director = value;
    }
    
    public IStrategy Strategy
    {
        get => curStrategy;
        set => curStrategy = value;
    }
}