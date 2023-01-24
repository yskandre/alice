using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IfTile : MonoBehaviour
{
    [SerializeField] MoveOrder allowedCommand;
    private void Start()
    {
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(92, 92, 112, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = "If(" + (allowedCommand == MoveOrder.forward ? "Fwd" : allowedCommand == MoveOrder.left ? "Left" : "Right");
    }
    public MoveOrder getAllowedCommand()
    {
        return allowedCommand;
    }
}
