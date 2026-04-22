using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winUI;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f; 
            winUI.SetActive(true);
        }
    }
}
