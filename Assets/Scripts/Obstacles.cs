using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IReactableObject
{
    /// <summary>
    /// This function relocates the character when it dies and adds one to the death counter
    /// </summary>
    public void React()
    {
        PlayerController.Pos = PlayerController.spawn.position;
        PlayerController.States = PlayerStates.Die;
        PlayerInfo.TotalDeaths += 1;
    }
}
