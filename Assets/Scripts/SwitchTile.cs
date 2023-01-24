using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTile : MonoBehaviour
{
    [SerializeField] CaseTile fwdCase;
    [SerializeField] CaseTile leftCase;
    [SerializeField] CaseTile rightCase;

    public CaseTile getFwdCase()
    {
        return fwdCase;
    }

    public CaseTile getLeftCase()
    {
        return leftCase;
    }

    public CaseTile getRightCase()
    {
        return rightCase;
    }
}
