using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Toggle toggle;
    
    private void Start()
    {
        // Set the initial state of the toggle based on the current audio pause state
        toggle.isOn = !AudioListener.pause;
    }
    
    public void ToggleMusic()
    {
        // Toggle the audio pause state based on the toggle's value
        AudioListener.pause = !toggle.isOn;
    }
}
