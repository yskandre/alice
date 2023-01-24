using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTile : MonoBehaviour
{
    [SerializeField] MoveOrder allowedCommand;

    public MoveOrder getAllowedCommand()
    {
        return allowedCommand;
    }
}
