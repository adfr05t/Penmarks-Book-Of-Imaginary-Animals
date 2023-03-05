using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Set in inspector
    [SerializeField] private string previousSceneName;


    public void TryAgain()
    {
        SceneManager.LoadSceneAsync(previousSceneName);
    }


    public void QuitToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
