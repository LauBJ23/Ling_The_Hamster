using UnityEngine;

public class Restart : MonoBehaviour
{
   public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LingScene");
        Time.timeScale = 1f;
    }
}
