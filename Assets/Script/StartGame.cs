using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                gameObject.SetActive(false);
            }
    }
}
