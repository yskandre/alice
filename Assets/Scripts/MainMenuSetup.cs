using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetup : MonoBehaviour
{
    private SystemData systemData;

    private void Start()
    {
        systemData = GameObject.Find("SystemData").GetComponent<SystemData>();
        systemData.UpdateMainMenu();
    }
}
