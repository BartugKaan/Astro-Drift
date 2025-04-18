using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float sceneLoadingDelay = 2f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;


    Movement movementScript;
    AudioSource audioSource;

    int currentScene;
    bool isControllable = true;
    bool isCollidable = true;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {

        if (!isControllable || !isCollidable) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Collision");
                break;
            case "Finish":
                LevelSequenceHandler("LoadNextLevel", successAudio, successParticles);
                break;
            default:
                LevelSequenceHandler("ReloadLevel", crashAudio, crashParticles);
                break;
        }
    }

    void LevelSequenceHandler(string methodName, AudioClip audio, ParticleSystem particleSystem)
    {
        particleSystem.Play();
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
