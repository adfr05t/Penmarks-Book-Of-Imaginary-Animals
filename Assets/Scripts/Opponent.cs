using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this script is almost identical to PlayerHealth.cs, currently

public class Opponent : MonoBehaviour
{
    public int health;
    public int maxHealth;

    [SerializeField] private TextMeshProUGUI healthDisplay;


    void Start()
    {
        health = maxHealth;
        UpdateHealthDisplay();
        // display updated playerHealth 
    }

    public void AdjustHealth(int adjustment)
    {
        health += adjustment;
        UpdateHealthDisplay();
        // display updated playerHealth 
    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text = health.ToString();
    }
}
