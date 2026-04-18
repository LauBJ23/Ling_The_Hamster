using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float distance = 20f;
    public float speed = 5f;
    private Vector3 startPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       startPos = transform.position;
       
    }
    // Update is called once per frame
    void Update()
    {
       float offset = Mathf.Sin(Time.time * speed) * distance;

        transform.position = new Vector3(
            startPos.x,
            startPos.y + offset,
            startPos.z
        );
 }
}


