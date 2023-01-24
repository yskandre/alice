using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaseTile : MonoBehaviour
{
    [SerializeField] MoveOrder option;
    [SerializeField] byte red = 159;
    [SerializeField] byte blue = 159;
    [SerializeField] byte green = 92;
    private void Start()
    {
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = "Case\n" + (option == MoveOrder.forward ? "Fwd" : option == MoveOrder.left ? "Left" : "Right");
    }
}
