using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAdvancer : MonoBehaviour
{
    [SerializeField] int codeID;
    [SerializeField] bool codeValue;
    [SerializeField] int botID;
    [SerializeField] bool botValue;
    
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] texts;
    private int counter;
    private SystemData systemData;

    private void Start() {
        systemData = GameObject.Find("SystemData").GetComponent<SystemData>();
        
        if(!(systemData.solvedCode[codeID] == codeValue && systemData.solvedBot[botID] == botValue)){
            panel.SetActive(false);
            return;
        }
        
        foreach (GameObject g in texts)
        {
            g.SetActive(false);
        }

        texts[0].SetActive(true);
        counter = 0;
    }

    public void Advance() {
        Debug.Log("...");
        texts[counter++].SetActive(false);
        if (counter >= texts.Length) panel.SetActive(false);
        else texts[counter].SetActive(true);
    }
}
