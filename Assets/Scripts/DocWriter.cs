using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocWriter : MonoBehaviour
{
    [SerializeField] GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        SystemData sys = GameObject.Find("SystemData").GetComponent<SystemData>();
        GameObject button;

        bg.SetActive(true);

        //bob
        button = GameObject.Find("Doc1");
        button.GetComponent<Image>().color = sys.solvedCode[0] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[0];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = "test";

        //cond
        button = GameObject.Find("Doc2");
        button.GetComponent<Image>().color = sys.solvedCode[2] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[2];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = "test";

        //loop
        button = GameObject.Find("Doc3");
        button.GetComponent<Image>().color = sys.solvedCode[3] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[3];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = "test";

        //queue
        button = GameObject.Find("Doc4");
        button.GetComponent<Image>().color = sys.solvedCode[5] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[5];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = ("test");

        //func
        button = GameObject.Find("Doc5");
        button.GetComponent<Image>().color = sys.solvedCode[6] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[6];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = ("test");

        bg.SetActive(false);
    }
}
