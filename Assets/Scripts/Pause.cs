using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public bool ispaused;

    public GameObject[] pause_UI;

    public GameObject[] removing_UI;

    public string levelname;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!ispaused)
            {
                ispaused = true;
                Time.timeScale = 0.0f;

                for (int i = 0; i < pause_UI.Length; i++)
                {
                    pause_UI[i].SetActive(true);
                }

                for (int i = 0; i < removing_UI.Length; i++)
                {
                    removing_UI[i].SetActive(false);
                }
            }
            else if(ispaused)
            {
                ispaused = false;
                Time.timeScale = 1.0f;

                for (int i = 0; i < pause_UI.Length; i++)
                {
                    pause_UI[i].SetActive(false);
                }

                for (int i = 0; i < removing_UI.Length; i++)
                {
                    removing_UI[i].SetActive(true);
                }
            }
        }

        if(ispaused)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(levelname);
            }
        }
	}
}
