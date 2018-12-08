using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private static int totalCubies;
    private static int totalStars;
    private static int totalDeaths;

    /// <summary>
    /// This property return the variable totalStars for be used and modified
    /// </summary> 
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

    /// <summary>
    /// This property return the variable totalStars for be used and modified
    /// </summary> 
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
