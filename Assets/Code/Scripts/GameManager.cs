public static class GameManager
{
    public static Mission[] missions = new Mission[]
    {
        new Mission("Destruir 10 dossies", 10),
        new Mission("Colocar virus em 5 computadores", 5),
        new Mission("Matar o peixe do chefe", 1)
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