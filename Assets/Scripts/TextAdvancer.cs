using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAdvancer : MonoBehaviour
{
    [SerializeField] bool unload;

    [SerializeField] bool checkCode;
    [SerializeField] int codeID;
    [SerializeField] bool codeValue;
    [SerializeField] bool checkBot;
    [SerializeField] int botID;
    [SerializeField] bool botValue;
    
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] texts;
    private int counter;
    private SystemData systemData;

    private void Start() {
        systemData = GameObject.Find("SystemData").GetComponent<SystemData>();
        
        if(unload) {
            panel.SetActive(false);
            return;
        }

        if (checkCode && checkBot) {
            if(!(systemData.solvedCode[codeID] == codeValue && systemData.solvedBot[botID] == botValue)){
                panel.SetActive(false);
                return;
            }
        } 
        else if (checkCode) {
            if(systemData.solvedCode[codeID] != codeValue){
                panel.SetActive(false);
                return;
            }
        }
        else if (checkBot) {
            if(systemData.solvedBot[botID] != botValue){
                panel.SetActive(false);
                return;
            }
        }
        
        foreach (GameObject g in texts)
        {
            g.SetActive(false);
        }

        texts[0].SetActive(true);
        counter = 0;
    }

    public void Advance() {
        texts[counter++].SetActive(false);
        if (counter >= texts.Length) panel.SetActive(false);
        else texts[counter].SetActive(true);
    }

    public void ResetText() {
        foreach (GameObject g in texts)
        {
            g.SetActive(false);
        }

        texts[0].SetActive(true);
        counter = 0;
    }
}
