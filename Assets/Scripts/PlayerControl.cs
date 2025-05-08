using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float turnSpeed = 100f;
    private float acceleration = 50f;
    private float maxSpeed = 200f;
    public float boatY = -50.2f;

    private float inputV;
    private float inputH;
    private float currentSpeed = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameObject.CompareTag("Player1"))
        {
            inputV = -(Input.GetAxis("Vertical_P2"));
            inputH = Input.GetAxis("Horizontal_P2");
        }

        if (gameObject.CompareTag("Player2"))
        {
            inputV = -(Input.GetAxis("Vertical"));
            inputH = Input.GetAxis("Horizontal");
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(inputV) > 0.1f)
        {
            currentSpeed += acceleration * inputV * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.fixedDeltaTime);
        }

        Vector3 move = transform.right * currentSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * inputH * turnSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = boatY;
        transform.position = pos;
    }
}
