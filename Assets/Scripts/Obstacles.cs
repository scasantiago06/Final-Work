using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IReactableObject
{
    public void React()
    {
        PlayerController.Pos = PlayerController.spawn.position;
        PlayerController.States = PlayerStates.Die;
        PlayerInfo.TotalDeaths += 1;
    }
}
