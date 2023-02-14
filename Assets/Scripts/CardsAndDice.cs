using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAndDice : MonoBehaviour
{
    [SerializeField] private Vector2 neutralPos;
    [SerializeField] private Vector2 playerTurnPos;
    [SerializeField] private Vector2 opponentTurnPos;
    // these might be in combatcontroller, instead
    private bool initialLerp = true;


    void Start()
    {
        
    }

    // for testing only
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(LerpFunction(opponentTurnPos));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(LerpFunction(neutralPos));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(LerpFunction(playerTurnPos));
        }
    }

    void LerpToNewPos()
    {
        //StartCoroutine(LerpFunction( ... ));
    }


    
    IEnumerator LerpFunction(Vector2 targetPos)
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
        Debug.Log(lerpDuration);
    }
}
