using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceClickAndDrag : MonoBehaviour
{
    // CardTriggerCollider is the coll that tells card dice is in place
    [SerializeField] private CircleCollider2D cardTriggerCollider;
    private Vector3 mouseOffset;


    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset = transform.position - mousePosition;
        // CardTriggerCollider is turned off when dragged, and on when dropped
        cardTriggerCollider.enabled = false;
    }


    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x + mouseOffset.x, mousePosition.y + mouseOffset.y, 0);
    }

    void OnMouseUp()
    {
        cardTriggerCollider.enabled = true;
    }
}
