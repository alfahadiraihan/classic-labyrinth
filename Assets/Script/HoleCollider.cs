using UnityEngine;
using TMPro;

public class HoleCollider : MonoBehaviour
{
    public GameObject levelFinishedPanel;
    public GameObject levelCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered the hole!");

            // Set time scale to 0
            Time.timeScale = 0f;

            // Activate the level finished panel
            levelFinishedPanel.SetActive(true);

            // Find the TimerText object within the LevelCanvas hierarchy
            GameObject timerTextObject = levelCanvas.transform.Find("TimerText").gameObject;

            // Find the TextMeshPro component within the TimerText object
            TextMeshProUGUI timerTextComponent = timerTextObject.GetComponent<TextMeshProUGUI>();

            // Update the text value of the TextMeshPro component
            timerTextComponent.text = "Goal!";

            // Disable the TimerText object
            timerTextObject.SetActive(false);
        }
    }
}
