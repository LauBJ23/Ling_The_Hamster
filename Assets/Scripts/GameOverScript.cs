using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverUI;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f; 
            GameOverUI.SetActive(true);
        }
    }
}
