using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButtonHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(GameObject.Find("SystemData").GetComponent<SystemData>().solvedCode[1]);
    }
}
