using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SystemData : MonoBehaviour
{
    public bool[] solvedCode = { false, false, false, false, false, false, false, false, false };
    public bool[] solvedBot = { false, false, false, false, false, false, false, false, false };

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
        GameObject button;

        button = GameObject.Find("Open");
        button.GetComponent<Image>().color = new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = true;

        button = GameObject.Find("Code1");
        button.GetComponent<Image>().color = solvedCode[0] ? new Color32(92, 159, 92, 255) : new Color32(255, 255, 255, 255);

        button = GameObject.Find("Level1");
        button.GetComponent<Image>().color = solvedBot[0] ? new Color32(92, 159, 92, 255) : solvedCode[0] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[0];


        button = GameObject.Find("Code2");
        button.GetComponent<Image>().color = solvedCode[1] ? new Color32(92, 159, 92, 255) : solvedBot[0] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedBot[0];

        button = GameObject.Find("Level2");
        button.GetComponent<Image>().color = solvedBot[1] ? new Color32(92, 159, 92, 255) : solvedCode[1] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[1];


        button = GameObject.Find("Code3");
        button.GetComponent<Image>().color = solvedCode[2] ? new Color32(92, 159, 92, 255) : solvedBot[1] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedBot[1];

        button = GameObject.Find("Level3");
        button.GetComponent<Image>().color = solvedBot[2] ? new Color32(92, 159, 92, 255) : solvedCode[2] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[2];

        button = GameObject.Find("Code4");
        button.GetComponent<Image>().color = solvedCode[3] ? new Color32(92, 159, 92, 255) : solvedBot[1] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedBot[1];

        button = GameObject.Find("Level4");
        button.GetComponent<Image>().color = solvedBot[3] ? new Color32(92, 159, 92, 255) : solvedCode[3] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[3];

        button = GameObject.Find("Code5");
        button.GetComponent<Image>().color = solvedCode[4] ? new Color32(92, 159, 92, 255) : solvedBot[1] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedBot[1];

        button = GameObject.Find("Level5");
        button.GetComponent<Image>().color = solvedBot[4] ? new Color32(92, 159, 92, 255) : solvedCode[4] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[4];


        button = GameObject.Find("Code6");
        button.GetComponent<Image>().color = solvedCode[5] ? new Color32(92, 159, 92, 255) : (solvedBot[2] && solvedBot[3] && solvedBot[4]) ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = (solvedBot[2] && solvedBot[3] && solvedBot[4]);

        button = GameObject.Find("Level6");
        button.GetComponent<Image>().color = solvedBot[5] ? new Color32(92, 159, 92, 255) : solvedCode[5] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[5];

        button = GameObject.Find("Code7");
        button.GetComponent<Image>().color = solvedCode[6] ? new Color32(92, 159, 92, 255) : (solvedBot[2] && solvedBot[3] && solvedBot[4]) ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = (solvedBot[2] && solvedBot[3] && solvedBot[4]);

        button = GameObject.Find("Level7");
        button.GetComponent<Image>().color = solvedBot[6] ? new Color32(92, 159, 92, 255) : solvedCode[6] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[6];

        button = GameObject.Find("Code8");
        button.GetComponent<Image>().color = solvedCode[7] ? new Color32(92, 159, 92, 255) : (solvedBot[2] && solvedBot[3] && solvedBot[4]) ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = (solvedBot[2] && solvedBot[3] && solvedBot[4]);

        button = GameObject.Find("Level8");
        button.GetComponent<Image>().color = solvedBot[7] ? new Color32(92, 159, 92, 255) : solvedCode[7] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[7];

        button = GameObject.Find("Code9");
        button.GetComponent<Image>().color = solvedCode[8] ? new Color32(92, 159, 92, 255) : (solvedBot[5] && solvedBot[6] && solvedBot[7]) ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = (solvedBot[5] && solvedBot[6] && solvedBot[7]);

        button = GameObject.Find("Level9");
        button.GetComponent<Image>().color = solvedBot[8] ? new Color32(92, 159, 92, 255) : solvedCode[8] ? new Color32(255, 255, 255, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = solvedCode[8];
    }
}
