using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchTile : MonoBehaviour
{
    [SerializeField] CaseTile fwdCase;
    [SerializeField] CaseTile leftCase;
    [SerializeField] CaseTile rightCase;
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
        text.GetComponent<TextMeshPro>().text = "Swi\ntch";
    }

    public CaseTile getFwdCase()
    {
        return fwdCase;
    }

    public CaseTile getLeftCase()
    {
        return leftCase;
    }

    public CaseTile getRightCase()
    {
        return rightCase;
    }
}
