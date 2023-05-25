using UnityEngine;

public class TimeFreezeManager : MonoBehaviour
{
    private bool isTimeFrozen = false;

    public void FreezeTime()
    {
        if (!isTimeFrozen)
        {
            Time.timeScale = 0f;
            isTimeFrozen = true;
        }
    }

    public void UnfreezeTime()
    {
        if (isTimeFrozen)
        {
            Time.timeScale = 1f;
            isTimeFrozen = false;
        }
    }
}
