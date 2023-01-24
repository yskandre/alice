using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockTile : MonoBehaviour
{
    [SerializeField] bool open = false;
    [SerializeField] byte red = 159;
    [SerializeField] byte blue = 92;
    [SerializeField] byte green = 159;
    private bool initialState;
    private void Start()
    {
        initialState = open;
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = open ? "Door\nOpen" : "Door\nShut";
    }

    public void ResetState()
    {
        open = initialState;
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = open ? "Door\nOpen" : "Door\nShut";
    }

    public void setOpen(bool value)
    {
        open = value;
        Transform background = transform.Find("Background");
        Transform text = background.Find("Text");
        text.GetComponent<TextMeshPro>().text = open ? "Door\nOpen" : "Door\nShut";
    }

    public bool isOpen()
    {
        return open;
    }
}
