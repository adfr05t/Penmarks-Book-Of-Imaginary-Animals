using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardData : ScriptableObject
{
    public enum CardType { Attack, Heal };
    public enum DiceTaken {Any, Min, Max, Specific, Odd, Even/*, ExceedTotal*/};
    
    public CardType cardType;
    public DiceTaken diceTaken;
    public int diceTakenSpecifier;
    public bool actionStrengthEqualsDieNum;
    public bool reusable;
    public int actionStrength; // may or may not be dependant on dice result
    public int damageDealt;
    

    public void Action(int numOnDie, Health health) // pass in dice result
    {
        if (DiceValid(numOnDie)) //pass dice result
        {
            if (actionStrengthEqualsDieNum)
            {
                actionStrength = numOnDie;
            }
 
            health.AdjustHealth(-actionStrength);
            Debug.Log("health adjusted");
        }
        else
        {
            Debug.Log(numOnDie + " is not a valid number for this card");
        }
    }

    public bool DiceValid(int numOnDie)
    {
        bool validity = false;

        switch (diceTaken)
        {
            case DiceTaken.Any:
                validity = true;
                break;

            case DiceTaken.Min:
                validity = (numOnDie >= diceTakenSpecifier) ? true : false;
                break;

            case DiceTaken.Max:
                validity = (numOnDie <= diceTakenSpecifier) ? true : false;
                break;

            case DiceTaken.Specific:
                validity = (numOnDie == diceTakenSpecifier) ? true : false;
                break;

            case DiceTaken.Odd:
                validity = (numOnDie % 2 != 0) ? true : false;
                Debug.Log("ODD------");
                break;

            case DiceTaken.Even:
                validity = (numOnDie % 2 == 0) ? true : false;
                Debug.Log("EVEN------");

                break;

            //case DiceTaken.ExceedTotal:

            //    break;
        }

        return validity;
    }
}
