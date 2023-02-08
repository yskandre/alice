using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SystemData : MonoBehaviour
{
    public bool[] solvedCode = { false, false, false, false, false, false, false, false, false, false };
    public bool[] solvedBot = { false, false, false, false, false, false, false, false, false };
    [SerializeField] GameObject challenge;

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

        foreach(bool b in solvedCode){
            if(!b) return;
        }

        foreach(bool b in solvedBot){
            if(!b) return;
        }

        challenge.SetActive(true);
    }
}
