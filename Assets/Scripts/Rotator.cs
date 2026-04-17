using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 120f;
    public float floatAmplitude = 0.15f; 
    public float floatFrequency = 2f;   

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
