using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f;   // Time limit in seconds
    public GameObject levelFinishedPanel; // Reference to the LevelFinishedPanel GameObject
    private string timeUpText = "Time's Up!"; // Text to display when the timer expires
    private float timer;            // Current timer value
    public bool isTimerRunning;    // Flag to track if the timer is running
    private TextMeshProUGUI timerText; // Reference to the TextMeshPro component to display the timer

    private void Awake()
    {
        levelFinishedPanel = GameObject.Find("LevelFinishedPanel");
    }

    private void Start()
    {
        // Find the TextMeshPro component on the same GameObject
        timerText = GetComponent<TextMeshProUGUI>();

        // Initialize the timer
        timer = timeLimit;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            // Update the timer
            timer -= Time.deltaTime;

            // Check if the timer has reached or exceeded zero
            if (timer <= 0f)
            {
                // Time is up! Perform the necessary actions (e.g., game over, level failed, etc.)
                TimerExpired();
            }

            // Update the UI text element to display the remaining time
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // Calculate the remaining seconds
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Update the TextMeshPro text with the remaining seconds
        timerText.text = string.Format("{0}", seconds);
    }

    private void TimerExpired()
    {
        // The timer has expired, perform the necessary actions (e.g., game over, level failed, etc.)
        isTimerRunning = false;

        //Enable the level finished panel
        levelFinishedPanel.SetActive(true);

        //Disable the timerText GameObject
        gameObject.SetActive(false);

        // Find the Text UI GameObject within the LevelFinishedPanel
        TextMeshProUGUI textUI = levelFinishedPanel.GetComponentInChildren<TextMeshProUGUI>();
        
        // Set the text of the Text UI GameObject to the specified timeUpText
        textUI.text = timeUpText;
        Debug.Log("Time's up!");

        //Set timeScale to 0 to pause the game
        Time.timeScale = 0f;
    }
}
