public static class GameManager
{
    public static int playerLifes = 3;

    public static int gameScore = 0; // Score from 0 to 1000

    public static Mission[] missions = new Mission[]
    {
        new Mission("No more paper stacks", 6),
        new Mission("'Fix' co-workers computers", 7),
        new Mission("Feed Memo (Boss's pet)", 1),
        new Mission("Cut down on the light bill", 1),
        new Mission("Leave Boss a scan at his door", 1)
    };
    public static bool[] missionComplete = new bool[missions.Length];

    public static void CompleteMission(int missionIndex)
    {
        if (missionIndex >= 0 && missionIndex < missions.Length)
        {
            missionComplete[missionIndex] = true;
        }
    }

    public static bool IsMissionComplete(int missionIndex)
    {
        if (missionIndex >= 0 && missionIndex < missions.Length)
        {
            return missionComplete[missionIndex];
        }
        return false;
    }

    public static bool AreAllMissionsComplete()
    {
        foreach (bool mission in missionComplete)
        {
            if (!mission)
            {
                return false;
            }
        }
        return true;
    }
}

public class Mission
{
    public string description;
    public int requiredCount;
    public int currentCount;

    public Mission(string description, int requiredCount)
    {
        this.description = description;
        this.requiredCount = requiredCount;
        this.currentCount = 0;
    }

    public bool IsComplete()
    {
        return currentCount >= requiredCount;
    }
}