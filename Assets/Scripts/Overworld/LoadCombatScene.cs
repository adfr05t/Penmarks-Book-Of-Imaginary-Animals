using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadCombatScene : MonoBehaviour
{
    // Set in inspector
    [SerializeField] private string nextCombatSceneName;


    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadSceneAsync(nextCombatSceneName);
    }
}
