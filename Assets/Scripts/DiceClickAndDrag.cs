using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceClickAndDrag : MonoBehaviour
{

    private Vector3 mouseOffset;


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
