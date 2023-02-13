using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private CombatController theCombatController;
    [SerializeField] GameObject cardsAndDice;

    void Start()
    {
        theCombatController = GetComponent<CombatController>();
    }


    public void UpdateState()
    {
            
    }

    // connect a UI button to this function
    public void EndTurn()
    {
        Debug.Log("PLayer turn ended");
        theCombatController.ChangeState(CombatController.CombatState.OpponentTurn);
    }
}
