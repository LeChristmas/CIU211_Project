using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string levelname;

    void Update ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play ()
    {
        SceneManager.LoadScene(levelname);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
