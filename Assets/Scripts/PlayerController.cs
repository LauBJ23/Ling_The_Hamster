using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasBanana = false;
    public bool hasCat = false;

    void Start()
    {
       
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
            else if (moveHorizontal > 0 && moveVertical > 0) 
                transform.rotation = Quaternion.Euler(0, 0, 45);
            else if (moveHorizontal < 0 && moveVertical == 0) 
                transform.rotation = Quaternion.Euler(0, 0, 135);
            else if (moveVertical > 0 && moveHorizontal == 0) 
                transform.rotation = Quaternion.Euler(0, 0, -45);
            else if (moveVertical < 0 && moveHorizontal == 0) 
                transform.rotation = Quaternion.Euler(0, 0, -135);
        }
    }

    //este método especial de unity se ejecuta cuando interactuamos con un objeto en modo Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            score = score + 1;//le sumo 1 a la variable score
            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
        }

        if (other.CompareTag("Banana"))
        {
            hasBanana = true;
            Debug.Log("BANANA Collected!");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Cat"))
        {
            hasCat = true;
            Debug.Log("Has tocado el gato, comunicate con el servicio tecnico de Samsung, Oh!");
        }

        if (score >= 3 && hasBanana == true && !hasCat)
        {
            Debug.Log("You Won!");
        }
    }
}