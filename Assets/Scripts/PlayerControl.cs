using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float turnSpeed = 100f;
    private float speed = 100f;
    private float inputV;
    private float inputH;
    private float boatY = -50.2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = boatY;
        transform.position = pos;
    }

    void Update()
    {
        if (gameObject.CompareTag("Player1"))
        {
            inputV = -(Input.GetAxis("Vertical"));
            inputH = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * inputV * speed * Time.deltaTime);
            transform.Rotate(inputH * Time.deltaTime * turnSpeed * Vector3.up);
        }

        if (gameObject.CompareTag("Player2"))
        {
            inputV = -(Input.GetAxis("Vertical_P2"));
            inputH = Input.GetAxis("Horizontal_P2");
            transform.Translate(Vector3.right * inputV * speed * Time.deltaTime);
            transform.Rotate(inputH * Time.deltaTime * turnSpeed * Vector3.up);
        }
    }
}
