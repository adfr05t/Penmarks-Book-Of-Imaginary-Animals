using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAndDice : MonoBehaviour
{
    private bool initialLerp = true;
    [SerializeField] private PlayerDice[] thePlayerDice;
    [SerializeField] private OpponentDice[] theOpponentDice;


     public void LerpCardsToNewPos(Vector2 targetPos)
    {
        StartCoroutine(LerpFunction(targetPos));
    }

    
    public IEnumerator LerpFunction(Vector2 targetPos)
    {
        float time = 0;
        Vector2 startPos = transform.position;
        float lerpDuration = 0.55f;

        if (initialLerp)
        {
            lerpDuration /= 2;
            initialLerp = false;
        }

        while (time < lerpDuration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / lerpDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        RollAllDice();
    }

    void RollAllDice()
    {
        for (int i = 0; i < thePlayerDice.Length; i++)
        {
            thePlayerDice[i].Roll();
        }
        for (int i = 0; i < thePlayerDice.Length; i++)
        {
            theOpponentDice[i].Roll();
        }
    }
}
