using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
