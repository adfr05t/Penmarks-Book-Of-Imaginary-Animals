using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public DiceData dice;
    private SpriteRenderer rend;
    public int myResult;
    private Vector3 mouseOffset;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // For testing only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myResult = dice.Roll();
            rend.sprite = dice.artwork[myResult - 1];
        }
    }


    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseOffset = transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x + mouseOffset.x, mousePosition.y + mouseOffset.y, 0);
    }
}
