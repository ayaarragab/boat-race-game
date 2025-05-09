using UnityEngine;

public class BoatReset : MonoBehaviour
{
    // Reference to the starting position GameObject
    public GameObject startPosition;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Store initial position and rotation from the startPosition GameObject
        if (startPosition != null)
        {
            initialPosition = startPosition.transform.position;
            initialRotation = startPosition.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Start position not assigned for " + gameObject.name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Skip reset if this object is Player1 or Player2 and collides with the other
        if ((gameObject.CompareTag("Player1") && collision.gameObject.CompareTag("Player2")) ||
            (gameObject.CompareTag("Player2") && collision.gameObject.CompareTag("Player1")))
        {
            return; // Exit without resetting
        }

        // Reset position and rotation for all other collisions
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Reset velocity if using Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}