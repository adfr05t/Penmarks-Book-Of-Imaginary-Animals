using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;

    [SerializeField] private TextMeshProUGUI healthDisplay;

    void Start()
    {
        playerHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void AdjustHealth(int adjustment)
    {
        playerHealth += adjustment;
        UpdateHealthDisplay();
        // display updated playerHealth 
    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text = playerHealth.ToString();
    }
}
