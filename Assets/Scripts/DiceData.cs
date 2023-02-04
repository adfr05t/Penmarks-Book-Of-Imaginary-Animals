using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDice", menuName = "Dice")]
public class DiceData : ScriptableObject
{
   // public int result;
    public Sprite[] artwork;
    public Sprite resultSprite;

    public int Roll()
    {
        int result = Random.Range(1, 7);
        Debug.Log(result);
        resultSprite = artwork[result - 1];

        return result;
    }
}
