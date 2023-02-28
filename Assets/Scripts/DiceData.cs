using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDice", menuName = "Dice")]
public class DiceData : ScriptableObject
{
    public Sprite[] artwork;

    public int Roll()
    {
        int result = Random.Range(1, 7);
        Debug.Log(result);

        return result;
    }
}
