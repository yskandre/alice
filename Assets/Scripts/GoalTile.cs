using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalTile : MonoBehaviour
{
    private void Start()
    {
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(92, 159, 92, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = "Goal";
    }
}
