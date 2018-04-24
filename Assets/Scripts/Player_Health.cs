using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public float health = 100;

    public Image health_bar;

    public GameObject[] death_UI;

    public string scene;

    private bool attack_dealy_bool;

    private bool dead;
	
	// Update is called once per frame
	void Update ()
    {
        health_bar.fillAmount = ((health - 0) / (100 - 0)) * (1 - 0) + 0;

        if(health <= 0)
        {
            Die();
        }


        if(Input.GetButtonDown("Fire2") && dead)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void Attacked(float damage)
    {
        if(!attack_dealy_bool)
        {
            attack_dealy_bool = true;
            health -= damage;
            StartCoroutine(Attack_Delay());
        }
    }

    IEnumerator Attack_Delay ()
    {
        yield return new WaitForSeconds(2.0f);
        attack_dealy_bool = false;
    }

    void Die()
    {
        if(!dead)
        {
            dead = true;
            for(int i = 0; i < death_UI.Length; i++)
            {
                death_UI[i].SetActive(true);
            }
        }
    }
}
