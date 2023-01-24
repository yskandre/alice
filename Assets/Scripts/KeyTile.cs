using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTile : MonoBehaviour
{
    [SerializeField] LockTile lockTile;
    [SerializeField] bool openLock;
    [SerializeField] byte red = 159;
    [SerializeField] byte blue = 92;
    [SerializeField] byte green = 159;
    private bool initialState;
    private void Start()
    {
        initialState = openLock;
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = openLock ? "Key\nOpen" : "Key\nShut";
    }

    public void ResetState()
    {
        openLock = initialState;
        Transform background = transform.Find("Background");
        Transform accent = transform.Find("Accent");
        Transform text = background.Find("Text");

        background.GetComponent<MeshRenderer>().material.color = new Color32(red, blue, green, 255);
        accent.gameObject.SetActive(false);
        text.GetComponent<TextMeshPro>().text = openLock ? "Key\nOpen" : "Key\nShut";
    }

    public void ChangeLock()
    {
        lockTile.setOpen(openLock);
        openLock = !openLock;
        Transform background = transform.Find("Background");
        Transform text = background.Find("Text");
        text.GetComponent<TextMeshPro>().text = openLock ? "Key\nOpen" : "Key\nShut";
    }
}
