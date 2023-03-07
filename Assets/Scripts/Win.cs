using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    // Set in inspector
    [SerializeField] private string nextSceneName;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        LoadNextScene();
    //    }
    //}

    // Called on UI button press
    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(nextSceneName);
    }

}
