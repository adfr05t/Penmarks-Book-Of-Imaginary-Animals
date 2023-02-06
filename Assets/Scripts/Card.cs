using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] CardData card;
    private Opponent currentOpponent;


    void Start()
    {
        currentOpponent = FindObjectOfType<Opponent>();
        card.theOpponent = currentOpponent;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int numOnDie = collision.GetComponent<Dice>().myResult;
        card.Action(numOnDie);
    }
}
