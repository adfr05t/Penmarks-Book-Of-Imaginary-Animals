using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // other: start, won, lost, playerActive...
    public enum Phase { PlayerTurn, OpponentTurn };
    public Phase currentPhase;

    [SerializeField] private DiceObject[] thePlayerDice;
    [SerializeField] private DiceObject[] theOpponentDice;
    [SerializeField] private CardObject[] thePlayerCards;
 //   [SerializeField] private GameObject[] thePlayerCardHolders;
    [SerializeField] private CardObject[] theOpponentCards;

    [SerializeField] private GameObject endTurnButton;

    [SerializeField] private float firstTurnDelay;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject youWonCanvas;




    void Start()
    {
        currentPhase = Phase.OpponentTurn;
        StartCoroutine(DelayFirstTurn());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AdvanceTurn();
        }
    }


    public void AdvanceTurn()
    {
        currentPhase++;

        if ((int)currentPhase >= System.Enum.GetValues(typeof(Phase)).Length)
        {
            currentPhase = 0;
        }

        switch (currentPhase)
        {
            case Phase.PlayerTurn:
                // Debug.Log("player's turn");
                endTurnButton.SetActive(true);
                SetCorrectCardsAndDiceActive();
                MoveCards();
                RollDice();
                MoveDice();
                break;

            case Phase.OpponentTurn:
                //  Debug.Log("opponent's turn");
                endTurnButton.SetActive(false);
                SetCorrectCardsAndDiceActive();
                MoveCards();
                RollDice();
                MoveDice();

                EnemyMovementTest();

                break;
        }
    }

    void EnemyMovementTest()
    {
            
    }


    void RollDice()
    {
        if (currentPhase == Phase.PlayerTurn)
        {
            foreach (var die in thePlayerDice)
            {
                die.Roll();
            }
        }
        else if (currentPhase == Phase.OpponentTurn)
        {
            foreach (var die in theOpponentDice)
            {
                die.Roll();
            }
        }
    }

    void MoveDice()
    {
        if (currentPhase == Phase.PlayerTurn)
        {
            foreach (var die in thePlayerDice)
            {
                die.MoveDice();
            }
        }
        else if (currentPhase == Phase.OpponentTurn)
        {
            foreach (var die in theOpponentDice)
            {
                die.MoveDice();
            }
        }
    }

    void MoveCards()
    {
        if (currentPhase == Phase.PlayerTurn)
        {
            foreach (var card in thePlayerCards)
            {
                card.MoveCard();
            }
        }
        else if (currentPhase == Phase.OpponentTurn)
        {
            foreach (var card in theOpponentCards)
            {
                card.MoveCard();
            }
        }
    }


    void SetCorrectCardsAndDiceActive()
    {
        if (currentPhase == Phase.PlayerTurn)
        {
            foreach (var die in theOpponentDice)
            {
                die.gameObject.SetActive(false);
            }
            foreach (var card in theOpponentCards)
            {
                card.gameObject.SetActive(false);
            }
            foreach (var die in thePlayerDice)
            {
                die.transform.parent = null;
                die.gameObject.SetActive(true);
            }
            //foreach (var cardHolder in thePlayerCardHolders)
            //{
            //    cardHolder.SetActive(true);
            //}
            foreach (var card in thePlayerCards)
            {
                card.gameObject.SetActive(true);
            }
        }
        else if (currentPhase == Phase.OpponentTurn)
        {
            foreach (var die in thePlayerDice)
            {
                die.gameObject.SetActive(false);
            }
            foreach (var card in thePlayerCards)
            {
                card.gameObject.SetActive(false);
            }
            foreach (var die in theOpponentDice)
            {
                die.transform.parent = null;
                die.gameObject.SetActive(true);
            }
            foreach (var card in theOpponentCards)
            {
                card.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator DelayFirstTurn()
    {
        yield return new WaitForSeconds(firstTurnDelay);
        AdvanceTurn();
    }


    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void YouWin()
    {
        youWonCanvas.SetActive(true);

    }

}
