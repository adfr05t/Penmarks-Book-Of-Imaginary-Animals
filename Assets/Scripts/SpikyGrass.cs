using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyGrass : MonoBehaviour
{
    // cards
    // dice

    // ENEMY MOVEMENT
    [SerializeField] private DiceObject[] myDice;
    [SerializeField] private CardObject[] myCards;

    [SerializeField] private float lerpDuration;
    [SerializeField] private bool moveInProgress;



    void Start()
    {
      //  StartCoroutine(MoveDiceToCard(myDice[0], myCards[0]));
    }


    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha9) && !moveInProgress)
        {
            StartCoroutine(MoveDiceToCard(myDice[0], myCards[0]));
            moveInProgress = true;
           // i++;
           // Debug.Log(i);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) && !moveInProgress)
        {
            StartCoroutine(MoveDiceToCard(myDice[1], myCards[1]));
            moveInProgress = true;
            // i++;
            // Debug.Log(i);
        }
        //  StartCoroutine(MoveDiceToCard(myDice[0], myCards[0]));

    }


    //void MoveDiceToCard(DiceObject die, CardObject card)
    //{
    //        StartCoroutine(LerpDice)
    //}

    IEnumerator MoveDiceToCard(DiceObject die, CardObject card)
        {

            float time = 0;
            Vector2 dieStartPos = die.transform.position;
            Vector2 cardPos = card.transform.position;

            while (time < lerpDuration)
            {
                die.transform.position = Vector2.Lerp(dieStartPos, cardPos, time / lerpDuration);
                time += Time.deltaTime;
                yield return null;
            }

            die.transform.position = cardPos;

            moveInProgress = false;

        TriggerCardAnimation(card);
    }

    void TriggerCardAnimation(CardObject card)
    {
        card.GetComponent<Animator>().SetTrigger("CardAction");
    }

}
