using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpdater : MonoBehaviour
{
    [SerializeField] bool checkCode;
    [SerializeField] int codeID;
    [SerializeField] bool checkBot;
    [SerializeField] int botID;

    // Start is called before the first frame update
    void Start()
    {
        var systemData = GameObject.Find("SystemData").GetComponent<SystemData>();
        
        if (checkCode) {
            if(systemData.solvedCode[codeID] == true){
                var img = GetComponent<Image>();
                img.color = new Color(img.color.r, img.color.g, img.color.b, .5f);
                return;
            }
        }
        else if (checkBot) {
            if(systemData.solvedBot[botID] == true){
                var img = GetComponent<Image>();
                img.color = new Color(img.color.r, img.color.g, img.color.b, .5f);
                return;
            }
        }
    }
}
