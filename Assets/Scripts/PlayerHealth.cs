using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;
    [SerializeField] private float adjustmentDelay;

    [SerializeField] private TextMeshProUGUI healthDisplay;

    void Start()
    {
        playerHealth = maxHealth;
        UpdateHealthDisplay();
    }

   public IEnumerator AdjustHealth(int adjustment)
    {
        yield return new WaitForSeconds(adjustmentDelay);
        playerHealth += adjustment;
        UpdateHealthDisplay();
        // display updated playerHealth 
    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text = playerHealth.ToString();
    }
}
