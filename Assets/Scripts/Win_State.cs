using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win_State : MonoBehaviour
{
    public string scene;

    public GameObject[] win_UI;

    public GameObject[] gun_status;

    public GameObject all_collectibles;

    private bool win;

    private GameObject player;

    private Collectibles collectible;

    public bool isgunactive;
    public bool allcollectibles;

    private int enemies_eliminated;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && win)
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

            isgunactive = collectible.gunactive;
            if (collectible.collectible_number == 4)
            {
                allcollectibles = true;
            }

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

            if(allcollectibles)
            {
                all_collectibles.SetActive(true);
            }

            if(isgunactive && collectible.enemies_killed > 0)
            {
                Debug.Log("Gun, Kills");
                gun_status[0].SetActive(true);
            }
            else if(isgunactive && collectible.enemies_killed <= 0)
            {
                Debug.Log("Gun, No Kills");
                gun_status[1].SetActive(true);
            }
            else if(!isgunactive && collectible.enemies_killed > 0)
            {
                Debug.Log("Gun, No Kills");
                gun_status[3].SetActive(true);
            }
            else
            {
                Debug.Log("No Gun, No Kills");
                gun_status[2].SetActive(true);
            }
        }
    }
}
