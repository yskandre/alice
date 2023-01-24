using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockTile : MonoBehaviour
{
    private bool open = false;
    [SerializeField] byte red = 159;
    [SerializeField] byte blue = 92;
    [SerializeField] byte green = 159;
    private void Start()
    {
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = open ? "Unlocked" : "Locked";
    }

    public void setOpen(bool value)
    {
        Transform text = transform.Find("Text");
        text.GetComponent<TextMeshPro>().text = open ? "Unlocked" : "Locked";
        open = value;
    }

    public bool isOpen()
    {
        return open;
    }
}
