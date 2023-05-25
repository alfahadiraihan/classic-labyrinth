using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //load scene by index
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        //quit the game
        Application.Quit();
        Debug.Log("Quit");
    }

    void Update()
    {
        //if back button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Switch case
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                //if current scene is the first scene
                case 0:
                    //quit the game
                    Application.Quit();
                    Debug.Log("Quit");
                    break;
                //if current scene is not the first scene
                default:
                    //load previous scene
                    Debug.Log("Loading previous scene");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    break;
            }
        }
    } 
}
