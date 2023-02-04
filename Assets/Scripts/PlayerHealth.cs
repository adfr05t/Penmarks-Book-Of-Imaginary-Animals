using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;

    void Start()
    {
        playerHealth = maxHealth;
    }

    public void AdjustHealth(int adjustment)
    {
        playerHealth += adjustment;

        // display updated playerHealth 
    }
}
