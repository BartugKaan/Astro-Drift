using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject playerRocket;
    [SerializeField] float movementSpeed = 5;

    bool isPlayPressed = false;

    public void PlayGame()
    {
        isPlayPressed = true;
        Invoke("LoadFirstLevel", 2);
    }

    void FixedUpdate()
    {
        if (isPlayPressed == true)
        {
            playerRocket.transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime * movementSpeed);
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        if (isPlayPressed == false)
        {
            Application.Quit();
        }
    }

}
