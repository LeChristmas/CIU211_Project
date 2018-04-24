using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_State : MonoBehaviour
{
    public string scene;

    public GameObject[] win_UI;

    private bool win;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(scene);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.tag == "Player")
        {
            Win();
        }
    }

    void Win()
    {
        if (!win)
        {
            win = true;
            for (int i = 0; i < win_UI.Length; i++)
            {
                win_UI[i].SetActive(true);
            }
        }
    }
}
