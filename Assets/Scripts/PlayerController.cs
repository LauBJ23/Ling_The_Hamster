using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //este método especial de unity se ejecuta cuando interactuamos con un objeto en modo Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectable"))
        {
            score = score + 1;//le sumo 1 a la variable score
            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
           
        }
        if(other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("KEY Collected!");
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Water"))
        {
            hasWater = true;
            Debug.Log("Has tocado el agua, comunicate con el servicio tecnico de Samsung, Oh!");
            
        }
                
        if (score >= 3 && hasKey == true && !hasWater) //
        {
            Debug.Log("You Won!");
        }
        /*else
        {
             Debug.Log("Keep trying, you need 3 and the KEY to win");
        }*/
    }

}
