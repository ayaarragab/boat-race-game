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
        // Freeze X and Z rotation to prevent physics-driven tilting
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
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
        // Handle movement
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

        // Handle player-controlled rotation
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * inputH * turnSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if collision is with another player or obstacle
        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2") ||
            collision.gameObject.CompareTag("Obstacle"))
        {
            // Stop physics-driven rotation
            rb.angularVelocity = Vector3.zero;

            // Enforce rotation constraints (lock X and Z, preserve Y)
            Vector3 currentEuler = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, currentEuler.y, 0);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Ensure rotation remains controlled during sustained collisions
        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2") ||
            collision.gameObject.CompareTag("Obstacle"))
        {
            rb.angularVelocity = Vector3.zero; // Prevent physics rotation
            // Reapply rotation constraints
            Vector3 currentEuler = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, currentEuler.y, 0);
        }
    }

    void LateUpdate()
    {
        // Lock Y position
        Vector3 pos = transform.position;
        pos.y = boatY;
        transform.position = pos;
    }
}