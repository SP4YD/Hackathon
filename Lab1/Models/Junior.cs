namespace Lab1.Models;

public class Junior
{
    private int id = -1;
    private string name = "";
    private int[] wishlistTL = null;

    public Junior(int newId, string newName)
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
    
    public int[] WishListTL
    {
        get => wishlistTL;
        set
        {
            wishlistTL = new int[value.Length];
            Array.Copy(value, wishlistTL, value.Length);
        }
    }
}