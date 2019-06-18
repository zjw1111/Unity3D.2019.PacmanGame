using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Again : MonoBehaviour
{
    public void PlayAgain()
    {
        Debug.Log("Again, Level: " + PlayerController.level);
        SceneManager.LoadScene("Level " + PlayerController.level.ToString());
    }
}
