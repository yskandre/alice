using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSlotResetter : MonoBehaviour
{
    public void ResetEverything(){
        foreach(CodeSlot c in GameObject.FindObjectsOfType<CodeSlot>()){
            c.ResetState();
        }

        foreach(DragDrop d in GameObject.FindObjectsOfType<DragDrop>()){
            d.ResetState();
        }
    }
}
