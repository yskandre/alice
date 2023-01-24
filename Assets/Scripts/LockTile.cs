using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTile : MonoBehaviour
{
    [SerializeField] GameObject tile;
    private bool open = false;

    public void setOpen(bool value)
    {
        tile.GetComponent<MeshRenderer>().material.color = value ? new Color32(92, 159, 92, 255) : new Color32(159, 92, 92, 255);
        open = value;
    }

    public bool isOpen()
    {
        return open;
    }
}
