namespace Lab1.Models;

public class ConductingHackathon
{
    public static void StartHackathon(List<Junior> juns, List<TeamLead> tls)
    {
        int[] arrayId = new int[juns.Count];
        for (int i = 0; i < juns.Count; ++i)
        {
            arrayId[i] = i;
        }

        foreach (var jun in juns)
        {
            Shuffle(arrayId);
            jun.WishListTL = arrayId;
        }
        
        foreach (var tl in tls)
        {
            Shuffle(arrayId);
            tl.WishListJun = arrayId;
        }
    }

    private static void Shuffle(int[] arr) {
        Random random = new Random((int)DateTime.Now.Ticks);
        for (int i = arr.Length - 1; i >= 1; i--) {
            int j = random.Next(i + 1);
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
    }
}