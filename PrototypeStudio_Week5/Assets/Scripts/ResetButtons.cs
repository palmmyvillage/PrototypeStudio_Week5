using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtons : MonoBehaviour
{
    public KeyCode resetScene, resetGame, quitGame, changeScene;
    public bool canChangeScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetScene();
        ResetGame();
        QuitGame();
        GoNextScene();
    }

    void ResetScene()
    {
        if (Input.GetKeyDown(resetScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Scene has reset.");
        }
    }

    void ResetGame()
    {
        if (Input.GetKeyDown(resetGame))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Game has been reset.");
        }
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(quitGame))
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }

    void GoNextScene()
    {
        if (canChangeScene == true)
        {
            if (Input.GetKeyDown(changeScene))
            {
                Debug.Log("Change Scene to Scene" + SceneManager.GetActiveScene().buildIndex+1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
