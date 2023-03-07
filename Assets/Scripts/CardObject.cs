using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    [SerializeField] CardData card;
//             private Opponent currentOpponent; 
    //private Player thePlayer;
    [SerializeField] private bool playerCard;

    [SerializeField] private Vector3 offscreenPos;
    [SerializeField] private Vector3 playingPos;
    [SerializeField] private float delayBeforeLerp;
    [SerializeField] private float lerpDuration;


    void Start()
    {
        if (playerCard)
        {
 //              currentOpponent = FindObjectOfType<Opponent>(); 
 //              card.theOpponent = currentOpponent;
            // currently the adjust health function is called in card (CardData.cs) - should change!
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int numOnDie = collision.GetComponent<DiceObject>().myResult;
        card.Action(numOnDie);
    }

    private void OnEnable()
    {
        transform.position = offscreenPos;
    }


    //TEST====================== working
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MoveCard();
        }
    }

    public void MoveCard()
    {
        StartCoroutine(DelayMove());
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(delayBeforeLerp);
        StartCoroutine(LerpCard());
    }

    IEnumerator LerpCard()
    {
        float time = 0;
        Vector3 startPos = transform.position;

        while (time < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPos, playingPos, time / lerpDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = playingPos;
    }
}
