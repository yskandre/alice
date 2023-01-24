using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTile : MonoBehaviour
{
    [SerializeField] bool active;

    public bool isActive()
    {
        return active;
    }
}
