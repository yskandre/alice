using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SystemData : MonoBehaviour
{
    public bool[] solvedCode = { false, false, false, false, false, false, false, false, false, false };
    public bool[] solvedBot = { false, false, false, false, false, false, false, false };
    
    public bool showOpening = true;

    public static SystemData Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void UpdateMainMenu()
    {
        if (SceneManager.GetActiveScene().name != "Main") return;

        if(!showOpening && GameObject.Find("Opening Text")) GameObject.Find("Opening Text").SetActive(false);

        foreach(bool b in solvedBot){
            if(!b) {
                if(GameObject.Find("Section5")) GameObject.Find("Section5").SetActive(false);
                if(GameObject.Find("Challenge Text")) GameObject.Find("Challenge Text").SetActive(false);
            }
        }
    }

    public void DisableOpening(){
        showOpening = false;
    }
}
