using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController2 : MonoBehaviour
{
    [SerializeField] CardsAndDice cardsAndDiceScript;

   // [SerializeField] private Vector2 neutralCardPos;
    [SerializeField] private Vector2 playerTurnCardPos;
    [SerializeField] private Vector2 opponentTurnCardPos;

    // public for testing
    public bool playerTurn;


    void Start()
    {
        playerTurn = true;
        MoveCards(playerTurnCardPos);
    }

    void Update()
    {
        
    }

    // what shall this cs do?
    // 1 move cards
    // 2 roll dice
    // switch to opponent ai turn at right time

    void MoveCards(Vector2 targetPos)
    {
        cardsAndDiceScript.LerpCardsToNewPos(targetPos);
    }
}
