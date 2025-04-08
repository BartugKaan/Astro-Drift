using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float sceneLoadingDelay = 2f;
    [SerializeField] AudioClip finishAudio;
    [SerializeField] AudioClip obstacleAudio;

    Movement movementScript;
    AudioSource audioSource;
    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Collision");
                break;
            case "Finish":
                LevelSequenceHandler("LoadNextLevel", finishAudio);
                break;
            default:
                LevelSequenceHandler("ReloadLevel", obstacleAudio);
                break;
        }
    }

    void LevelSequenceHandler(string methodName, AudioClip audio)
    {
        //todo add sfx and particles
        audioSource.PlayOneShot(audio);
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
