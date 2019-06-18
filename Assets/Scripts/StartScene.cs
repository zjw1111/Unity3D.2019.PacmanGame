using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button btnStart;
    public Button btnQuit;

    // Start is called before the first frame update
    void Start()
    {
        btnStart.onClick.AddListener(PlayGame);
        btnQuit.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("Play Game");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
