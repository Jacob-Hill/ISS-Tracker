using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float turnSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * turnSpeed  * Time.deltaTime);
    }
}
