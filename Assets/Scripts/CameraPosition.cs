using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;

    // Configurable camera settings
    private Vector3 positionOffset = new Vector3(-54, 39, -1);
    private bool smoothFollow = true;
    private float followSpeed = 5f;

    // Camera behavior options
    private bool matchPlayerRotation = false;
    private bool lookAtPlayer = true;
    private float rotationDamping = 2f;

    // Optional screen shake effect
    private float shakeAmount = 0f;
    private float shakeDuration = 0f;
    private Vector3 originalPosition;
    private void Start()
    {
        
        if (player == null)
        {
            Debug.LogError("Player reference not set in CameraPosition script!");
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                Debug.LogError("No player found with 'Player' tag!");
        }

        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = player.transform.position + positionOffset;

        // Apply smooth follow if enabled
        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = targetPosition;
        }

        // Handle rotation options
        if (matchPlayerRotation)
        {
            transform.rotation = player.transform.rotation;
        }
        else if (lookAtPlayer)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
        }

        // Apply screen shake if active
        if (shakeDuration > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
    }

    // Call this method to trigger a screen shake
    public void ShakeCamera(float amount, float duration)
    {
        shakeAmount = amount;
        shakeDuration = duration;
    }
}