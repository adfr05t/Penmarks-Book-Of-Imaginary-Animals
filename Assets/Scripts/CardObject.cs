using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    [SerializeField] CardData card;
    private Opponent currentOpponent;

    [SerializeField] private Vector2 offscreenPos;
    [SerializeField] private Vector2 playingPos;
    [SerializeField] private float delayBeforeLerp;
    [SerializeField] private float lerpDuration;


    void Start()
    {
        currentOpponent = FindObjectOfType<Opponent>();
        card.theOpponent = currentOpponent;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int numOnDie = collision.GetComponent<DiceObject>().myResult;
        card.Action(numOnDie);
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
        Vector2 startPos = transform.position;

        while (time < lerpDuration)
        {
            transform.position = Vector2.Lerp(startPos, playingPos, time / lerpDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = playingPos;
    }
}
