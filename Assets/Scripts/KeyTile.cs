using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : MonoBehaviour
{
    [SerializeField] LockTile lockTile;
    [SerializeField] bool openLock;

    public void ChangeLock()
    {
        lockTile.setOpen(openLock);
    }
}
