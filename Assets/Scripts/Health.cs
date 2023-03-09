using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this script is almost identical to PlayerHealth.cs, currently

public class Health : MonoBehaviour
{
    [SerializeField] private bool thisIsPlayersHealth;
    private int currentHealth;
    [SerializeField] private int maxHealth;
    private float healthBarUnits;
    [SerializeField] private TextMeshProUGUI currentHealthTextDisplay;
    [SerializeField] private TextMeshProUGUI maxHealthTextDisplay;
    [SerializeField] private SpriteRenderer healthFill;
    [SerializeField] private BattleController theBattleController;



    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
        maxHealthTextDisplay.text = maxHealth.ToString();
        // 4.16 and 0.1 are the health fill x sizes at full/zero health, respectively
        healthBarUnits = (4.3f - 0.1f) / maxHealth;
    }


    // FOR TESTING ONLY:
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        AdjustHealth(-1);
    //    }
    //}


    public void AdjustHealth(int adjustment)
    {
        currentHealth += adjustment;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthDisplay();
        // 0.1 is length of fill at zero health
        healthFill.size = new Vector2(0.1f + (currentHealth * healthBarUnits), healthFill.size.y);

        if (currentHealth == 0)
        {
            EndBattle();
        }
    }


    void UpdateHealthDisplay()
    {
        currentHealthTextDisplay.text = currentHealth.ToString();
    }


    void EndBattle()
    {
            if (thisIsPlayersHealth)
            {
                // set game over canvas active
                 Debug.Log("GAME OVER");
                theBattleController.GameOver();
            }
            else
            {
                // set win canvas active
                Debug.Log("YOU WON!!");
                theBattleController.YouWin();
            }
    }
}
