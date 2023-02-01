using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodeSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int slotId;
    public GameObject lastDrop;
    public bool droppedOn = false;
    int optionId;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            droppedOn = true;
            lastDrop = eventData.pointerDrag;
            lastDrop.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            lastDrop.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
            lastDrop.GetComponent<DragDrop>().slotted = true;
            optionId = lastDrop.GetComponent<DragDrop>().id;
        }
    }

    public bool CheckMatch()
    {
        return slotId == optionId;
    }

    public void ResetState(){
        GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        lastDrop = null;
        droppedOn = false;
        optionId = -1;
    }
}
