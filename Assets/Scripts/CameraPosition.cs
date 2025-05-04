using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;

    [Header("Camera Follow Settings")]
    private Vector3 localOffset = new Vector3(5.83f, 2, -0.3f); // height and distance behind boat
    public float followSpeed = 5f;

    [Header("Look Ahead Settings")]
    private float lookAheadDistance = -1.05f; // how far the camera looks ahead of the boat
    public float rotationDamping = 2f;

    [Header("Optional Screen Shake")]
    public float shakeAmount = 0f;
    public float shakeDuration = 0f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in CameraPosition script!");
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                Debug.LogError("No player found with 'Player' tag!");
        }
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        // Desired position is behind the player in local space (relative to boat’s rotation)
        Vector3 desiredPosition = player.transform.TransformPoint(localOffset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Look ahead based on the boat's forward direction
        Vector3 lookTarget = player.transform.position + player.transform.forward * lookAheadDistance;
        Quaternion desiredRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);

        // Optional shake
        if (shakeDuration > 0f)
        {
            transform.position += Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float amount, float duration)
    {
        shakeAmount = amount;
        shakeDuration = duration;
    }
}
