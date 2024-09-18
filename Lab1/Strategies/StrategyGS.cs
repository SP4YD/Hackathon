namespace Lab1.Strategies;

public class StrategyGS : IStrategy
{
    public int[] Execute(int[][] juniorPrefs, int[][] teamLeadPrefs)
    {
        int n = juniorPrefs.Length;
        bool[] freeJuniors = new bool[n];
        int[] matches = new int[n];
        int[] nextProposal = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            matches[i] = -1; 
            freeJuniors[i] = true;
        }
        
        while (Array.Exists(freeJuniors, x => x))
        {
            int junior = Array.IndexOf(freeJuniors, true);

            while (nextProposal[junior] < n && freeJuniors[junior])
            {
                int teamLead = juniorPrefs[junior][nextProposal[junior]];
                nextProposal[junior]++;

                if (matches[teamLead] == -1)
                {
                    matches[teamLead] = junior;
                    freeJuniors[junior] = false;
                }
                else
                {
                    int currentJunior = matches[teamLead];
                    if (GetRank(teamLeadPrefs[teamLead], junior) < GetRank(teamLeadPrefs[teamLead], currentJunior))
                    {
                        matches[teamLead] = junior;
                        freeJuniors[junior] = false;
                        freeJuniors[currentJunior] = true;
                    }
                }
            }
        }

        return matches;
    }

    static int GetRank(int[] preferences, int junior)
    {
        return Array.IndexOf(preferences, junior);
    }
}
