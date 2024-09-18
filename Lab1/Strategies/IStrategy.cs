namespace Lab1.Strategies;

public interface IStrategy
{
    int[] Execute(int[][] juniorPrefs, int[][] teamLeadPrefs);
}