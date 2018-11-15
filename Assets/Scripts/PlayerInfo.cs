using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private static int totalCubies;
    private static int totalStars;
    private static int totalDeaths;

    public static int TotalCubies
    {
        get
        {
            return totalCubies;
        }
        set
        {
            totalCubies = value;
        }
    }

    public static int TotalStars
    {
        get
        {
            return totalStars;
        }
        set
        {
            totalStars = value;
        }
    }

    public static int TotalDeaths
    {
        get
        {
            return totalDeaths;
        }
        set
        {
            totalDeaths = value;
        }
    }
}
