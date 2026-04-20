using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int seed = 0;
    public int totalWorms = 5;
    public int bananas = 0;
    public int totalBananas = 1;
    public bool hasBanana = false;
    public bool hasCat = false;
    public TextMeshProUGUI textSeed;
    public TextMeshProUGUI textBanana;
    public TextMeshProUGUI textWorms;
    public TextMeshProUGUI notificationText;


    void Start()
    {
       UpdateTextScore();
       notificationText.gameObject.SetActive(false);

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0).normalized;
        
        
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

       
        if (direction != Vector3.zero)
        {
            if (moveHorizontal > 0) // Derecha
                transform.rotation = Quaternion.Euler(0, 0, 270);
            else if (moveHorizontal < 0) // Izquierda
                transform.rotation = Quaternion.Euler(0, 0, 90);
            else if (moveVertical > 0) // Arriba
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (moveVertical < 0) // Abajo
                transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            seed = seed + 1;
            UpdateTextScore();

            Destroy(other.gameObject);
            ShowNotification("Collected!");
            Debug.Log("Seeds: " + seed);
        }
        if (other.CompareTag("Collectable1"))
        {
            worm = worm + 1;
            UpdateTextScore();

            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
            ShowNotification("Collected!");
            Debug.Log("Worms: " + worm);
        }

        if (other.CompareTag("Banana"))
        {
            hasBanana = true;
            ShowNotification("You've collected the banana!");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Cat"))
        {
            hasCat = true;
            ShowNotification("The cat got you!!");
            Destroy(gameObject);
        }

        if (seed == 10 && worm==5  && hasBanana == true && !hasCat)
        {
            Debug.Log("You made it! You ate all the treats and skipped the cat!");
        }
    }
     void UpdateTextScore()
    {
        textSeed.text = "Seeds: " + seed + "/" + totalSeeds;
        textBanana.text = "Bananas: " + bananas + "/" + totalBananas;
        textWorms.text = "Worms: " + worm + "/" + totalWorms;
    }

    void ShowNotification(string message)
    {
        StartCoroutine(ShowMessageRoutine(message));
        IEnumerator ShowMessageRoutine(string message)
        {
            notificationText.text = message;
            notificationText.gameObject.SetActive(true);

            yield return new WaitForSeconds(2f); 
            notificationText.gameObject.SetActive(false);
        }
    }
}