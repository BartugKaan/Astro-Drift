using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Movement movementScript;
    int currentScene;
    [SerializeField] float sceneLoadingDelay = 2f;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        movementScript = GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Collision");
                break;
            case "Finish":
                LevelSequenceHandler("LoadNextLevel");
                break;
            default:
                LevelSequenceHandler("ReloadLevel");
                break;
        }
    }

    void LevelSequenceHandler(string methodName)
    {
        //todo add sfx and particles
        movementScript.enabled = false;
        Invoke(methodName, sceneLoadingDelay);
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextLevel()
    {

        int nextSceneIndex = currentScene + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


}
