using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject : MonoBehaviour
{
    public DiceData dice;
    private SpriteRenderer rend;
    public int myResult;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    public void Roll()
    {
        myResult = dice.Roll();
        rend.sprite = dice.resultSprite;
    }
}
