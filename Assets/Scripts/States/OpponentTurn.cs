using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTurn : MonoBehaviour
{
    private CombatController theCombatController;

    void Start()
    {
        theCombatController = GetComponent<CombatController>();
    }

    public void UpdateState()
    {
        Debug.Log("Opponent plays turn");
        EndTurn();
    }

    void EndTurn()
    {
        theCombatController.ChangeState(CombatController.CombatState.PlayerTurn);

    }
}
