using UnityEngine;

public class LevelCanvasManager : MonoBehaviour
{
    private GameObject levelFinishedPanel;

    private void Start()
    {
        // Find the LevelFinishedPanel child GameObject
        levelFinishedPanel = transform.Find("LevelFinishedPanel").gameObject;
        levelFinishedPanel.SetActive(false);
    }
}
