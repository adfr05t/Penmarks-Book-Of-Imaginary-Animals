using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    public DiceData dice;
    private SpriteRenderer rend;
    public int myResult;
    private Vector3 mouseOffset;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    public void Roll()
    {
            myResult = dice.Roll();
            rend.sprite = dice.artwork[myResult - 1];
    }
}
