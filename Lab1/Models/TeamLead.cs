namespace Lab1.Models;

public class TeamLead
{
    private int id = -1;
    private string name = "";
    private int[] wishlistJun = null;

    public TeamLead(int newId, string newName)
    {
        id = newId;
        name = newName;
    }

    public int ID
    {
        get => id;
    }
    
    public string Name
    {
        get => name;
    }
    
    public int[] WishListJun
    {
        get => wishlistJun;
        set
        {
            wishlistJun = new int[value.Length];
            Array.Copy(value, wishlistJun, value.Length);
        }
    }
}