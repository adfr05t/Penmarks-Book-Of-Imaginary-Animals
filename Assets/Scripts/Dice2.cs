using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dice", menuName = "Dice")]
public class Dice2 : ScriptableObject
{
    public int result;
    public Sprite[] artwork;
    public Sprite resultSprite;

    public void Roll()
    {
        result = Random.Range(1, 7);
        Debug.Log(result);
        resultSprite = artwork[result - 1];
    }
}
