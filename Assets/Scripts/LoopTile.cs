using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTile : MonoBehaviour
{
    [SerializeField] MoveOrder loopCommand;
    [SerializeField] int loopAmount;

    public MoveOrder getLoopCommand()
    {
        return loopCommand;
    }

    public int getLoopAmount()
    {
        return loopAmount;
    }
}
