using UnityEngine;
using UnityEngine.SceneManagement;

public class NotificationScene : MonoBehaviour
{

  public void ReturnToMainScene()
  {
    SceneManager.LoadSceneAsync(0);
  }

}
