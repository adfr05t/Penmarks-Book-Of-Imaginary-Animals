using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMeOff : MonoBehaviour
{
    [SerializeField] GameObject objectToTurnOff;


    public void TurnOff()
    {
        objectToTurnOff.SetActive(false);
    }
}
