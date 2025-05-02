using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float turnSpeed = 100f;
    private float speed = 100f;
    private float inputV;
    private float inputH;
    private float boatY = -50.2f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void LateUpdate()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        pos.y = boatY;
        transform.position = pos;
    }
    void Update()
    {
        // Clamp Y position to a fixed value (e.g., 8)
        transform.position = new Vector3(transform.position.x, boatY, transform.position.z);
        inputV = -(Input.GetAxis("Vertical"));
        inputH = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * inputV * speed * Time.deltaTime);
        transform.Rotate(inputH * Time.deltaTime * turnSpeed * Vector3.up);
    }


}
