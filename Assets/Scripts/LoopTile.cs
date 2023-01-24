using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopTile : MonoBehaviour
{
    [SerializeField] MoveOrder loopCommand;
    [SerializeField] int loopAmount;
    private void Start()
    {
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(92, 92, 159, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = (loopCommand == MoveOrder.forward ? "Fwd" : loopCommand == MoveOrder.left ? "Left" : "Right") + "x" + loopAmount;
    }

    public MoveOrder getLoopCommand()
    {
        return loopCommand;
    }

    public int getLoopAmount()
    {
        return loopAmount;
    }
}
