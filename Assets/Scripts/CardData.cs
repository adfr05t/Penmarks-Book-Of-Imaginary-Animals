using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardData : ScriptableObject
{
    public enum CardType { Attack, Defence, Heal };
    public enum DiceTaken {Any, Min, Max, Specific, Odd, Even, ExceedTotal};
    
    public CardType cardType;
    public DiceTaken diceTaken;
    public int diceTakenSpecifier;
    
    public string nameOfCard;
    public string description;

    public Sprite artwork;

    public int damageDealt;

    // FUNCTIONS:
    // check dice is valid
    // carry out action
    public void Action(int numOnDie) // pass in dice result
    {
        if (DiceValid(numOnDie)) //pass dice result
        {
            // switch () // action depends on card type enum selected
            Debug.Log(nameOfCard + ": Action");
        }
        else
        {
            Debug.Log(numOnDie + " is not a valid number for this card");
        }
        
    }

    bool DiceValid(int numOnDie)
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

                break;

            case DiceTaken.Even:

                break;

            case DiceTaken.ExceedTotal:

                break;
        }

        return validity;
    }
}
