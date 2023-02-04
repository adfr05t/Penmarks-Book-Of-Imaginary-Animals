using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] CardData card;
        
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int numOnDie = collision.GetComponent<Dice>().myResult;
        Debug.Log("number on colliding dice = " + numOnDie.ToString());
        card.Action(numOnDie);
    }
}
