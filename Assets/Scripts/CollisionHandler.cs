using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Collision");
                break;
            case "Finish":
                Debug.Log("Level Finished");
                break;
            case "Obstacle":
                Debug.Log("You hit obstacle!");
                ReloadLevel();
                break;
            default:
                Debug.Log("You hit something!");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
