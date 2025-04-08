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
    bool isControllable = true;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {

        if (!isControllable) { return; }

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
        //todo add particles
        audioSource.PlayOneShot(audio);
        movementScript.enabled = false;
        Invoke(methodName, sceneLoadingDelay);
    }


    void ReloadLevel()
    {
        isControllable = false;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextLevel()
    {
        isControllable = false;
        int nextSceneIndex = currentScene + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


}
