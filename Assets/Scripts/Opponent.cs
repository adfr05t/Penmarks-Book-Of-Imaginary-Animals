using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    // cards
    // dice
    [SerializeField] private BattleController theBattleController;
    // ENEMY MOVEMENT
    [SerializeField] private DiceObject[] myDice;
    [SerializeField] private CardObject[] myCards;
    private List<CardObject> cardList;
    private List<DiceObject> diceList;

    [SerializeField] private float lerpDuration;
    [SerializeField] private bool moveInProgress;
    [SerializeField] private Health playerHealth;
    [SerializeField] private float pauseLengthBetweenMoves;
    [SerializeField] private float pauseLengthAtStart;
    [SerializeField] private float pauseLengthAtEndOfTurn;


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
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartMyTurn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TakeATurn();
        }
    }

    public void StartMyTurn()
    {
    // put dice and cards in lists at start of turn (then remove after use, so neither will be used more than once).
        diceList = new List<DiceObject>();
        foreach (var die in myDice)
        {
            diceList.Add(die);
        }

        cardList = new List<CardObject>();
        foreach (var card in myCards)
        {
            cardList.Add(card);
        }

        StartCoroutine(PauseAtStartOfTurn());
    }

    void TakeATurn()
    {// for this enemy there is no 'best move' to calculate
        Debug.Log("Taking a turn");

        bool noMovePossible = false;

        foreach (var die in diceList)
        {
            foreach (var card in cardList)
            {
                if (card.card.DiceValid(die.myResult))
                {
                    StartCoroutine(MoveDiceToCard(die, card));
                    diceList.Remove(die);
                    cardList.Remove(card);
                    return;
                }
            }
            noMovePossible = true;
        }

        if (cardList.Count == 0 || diceList.Count == 0 || noMovePossible)
        {
          StartCoroutine(EndMyTurn());
        }
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
        die.transform.parent = card.transform;

            moveInProgress = false;

        TriggerCardAnimation(card);

        // delay this to sync with animation, and add a hurt anim to player
        //    playerHealth.AdjustHealth()
        card.card.Action(die.myResult, playerHealth);

        StartCoroutine(PauseBetweenMoves());
    }

    void TriggerCardAnimation(CardObject card)
    {
        card.GetComponentInParent<Animator>().SetTrigger("CardAction");
    }

    IEnumerator PauseBetweenMoves()
    {
        yield return new WaitForSeconds(pauseLengthBetweenMoves);
        TakeATurn();
    }

    IEnumerator PauseAtStartOfTurn()
    {
        yield return new WaitForSeconds(pauseLengthAtStart);
        TakeATurn();
    }

    IEnumerator EndMyTurn()
    {
        yield return new WaitForSeconds(pauseLengthAtEndOfTurn);
        theBattleController.AdvanceTurn();
    }

}
