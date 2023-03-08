using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector2(0, 0);
        Debug.Log("pos reset??");
    }
}
