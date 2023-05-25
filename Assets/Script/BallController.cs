using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    private float respawnThreshold = -1f;
    private bool gameStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Check if gyroscope is available
        if (SystemInfo.supportsGyroscope)
        {
            // Enable gyroscope
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.Log("Gyroscope not supported on this device.");
        }

        // Store initial position
        initialPosition = transform.position;

        // Pause the game initially
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Check if the game has started
        if (!gameStarted)
        {
            // Check for the first touch/click
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                // Resume the game
                Time.timeScale = 1f;

                // Set the game as started
                gameStarted = true;
                
            }
            else
            {
                // Keep the game paused
                return;
            }
        }

        // Check if gyroscope is enabled
        if (Input.gyro.enabled)
        {
            // Get the gyroscope input
            Vector3 gyroInput = Input.gyro.gravity;

            // Apply the gyroscope input to the ball's Rigidbody component
            rb.AddForce(gyroInput.x, 0f, gyroInput.y);
        }

        // Check if the ball falls below the respawn threshold
        if (transform.position.y < respawnThreshold)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reset the ball's position to the initial position
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
