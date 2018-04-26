using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win_State : MonoBehaviour
{
    public string scene;

    public GameObject[] win_UI;

    private bool win;

    private GameObject player;

    private Collectibles collectible;

    private int enemies_eliminated;
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
            player = col.transform.gameObject;
            collectible = player.GetComponent<Collectibles>();
            win_UI[0].GetComponent<Text>().text = ("Enemies Eliminated: " + collectible.enemies_killed);
            win_UI[1].GetComponent<Image>().color = collectible.collectible_icons[0].color;
            win_UI[2].GetComponent<Image>().color = collectible.collectible_icons[1].color;
            win_UI[3].GetComponent<Image>().color = collectible.collectible_icons[2].color;
            win_UI[4].GetComponent<Image>().color = collectible.collectible_icons[3].color;
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
