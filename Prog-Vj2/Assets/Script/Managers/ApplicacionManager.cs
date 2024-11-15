using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicacionManager : MonoBehaviour
{
    public static ApplicacionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay mas escenas despues de la actual.");
        }
    }

    public void GoToPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previusSceneIndex = currentSceneIndex - 1;

        if(previusSceneIndex >= 0)
        {
            SceneManager.LoadScene(previusSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay mas escenas previas a la actual.");
        }
    }
}
