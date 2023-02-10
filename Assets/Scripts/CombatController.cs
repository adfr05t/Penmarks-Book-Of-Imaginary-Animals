using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    //[SerializeField] private StartCombat;
    //[SerializeField] private PlayerTurn;
    //[SerializeField] private OpponentTurn
    //[SerializeField] private WonBattle;
    //[SerializeField] private LostBattle;

    public enum CombatState { Start, PlayerTurn, OpponentTurn, Won, Lost };
    public CombatState currentState;

    [SerializeField] CardData[] opponentCards;

    void Start()
    {
        currentState = CombatState.Start; 
        // I'm not sure I even need a start state....
        // Roll player dice here 
    }

    void Update()
    {
        switch (currentState)
        {
            case CombatState.Start:

                break;

            case CombatState.PlayerTurn:

                break;

            case CombatState.OpponentTurn:

                break;

            case CombatState.Won:

                break;

            case CombatState.Lost:

                break;
        }
    }

    public void ChangeState(CombatState newState)
    {
        currentState = newState;
    }

}
