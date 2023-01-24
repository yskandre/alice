using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compiler : MonoBehaviour
{
    [SerializeField] int levelID;
    [SerializeField] CodeSlot[] slots;
    private SystemData systemData;

    private void Start()
    {
        systemData = GameObject.Find("SystemData").GetComponent<SystemData>();
    }
    public void CheckCode()
    {
        bool solved = true;

        foreach (var slot in slots)
        {
            if (!slot.droppedOn)
            {
                solved = false;
                slot.GetComponent<Image>().color = new Color32(159, 92, 92, 255);
            }
            else if (slot.CheckMatch())
            {
                slot.GetComponent<Image>().color = new Color32(92, 159, 92, 255);
                slot.lastDrop.GetComponent<Image>().color = new Color32(92, 159, 92, 255);
            }
            else
            {
                solved = false;
                slot.GetComponent<Image>().color = new Color32(159, 92, 92, 255);
                slot.lastDrop.GetComponent<Image>().color = new Color32(159, 92, 92, 255);
            }
        }

        if (solved)
        {
            systemData.solvedCode[levelID] = true;
        }
    }
}
