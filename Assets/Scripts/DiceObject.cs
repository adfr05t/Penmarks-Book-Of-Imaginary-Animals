using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject : MonoBehaviour
{
    public DiceData dice;
    private SpriteRenderer rend;
    public int myResult;

    [SerializeField] private Vector2 offscreenPos;
    [SerializeField] private Vector2 playingPos;
    [SerializeField] private float delayBeforeLerp;
    [SerializeField] private float lerpDuration;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    public void Roll()
    {
        myResult = dice.Roll();
        rend.sprite = dice.resultSprite;
    }

    private void OnEnable()
    {
        transform.position = offscreenPos;
    }


    public void MoveDice()
    {
        StartCoroutine(DelayMove());
    }


    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(delayBeforeLerp);
        StartCoroutine(LerpDice());
    }


    IEnumerator LerpDice()
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
