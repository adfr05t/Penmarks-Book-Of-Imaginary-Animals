using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // other: start, won, lost, playerActive...
    public enum Phase { PlayerTurn, OpponentTurn };
    public Phase currentPhase;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AdvanceTurn();
        }
    }


    void AdvanceTurn()
    {
        currentPhase++;

        if ((int)currentPhase >= System.Enum.GetValues(typeof(Phase)).Length)
        {
            currentPhase = 0;
        }

        switch (currentPhase)
        {
            case Phase.PlayerTurn:
                Debug.Log("player's turn");
               // playerTurn.UpdateState();
                break;

            case Phase.OpponentTurn:
                Debug.Log("opponent's turn");
                // opponentTurn.UpdateState();
                break;
        }
    }
}
