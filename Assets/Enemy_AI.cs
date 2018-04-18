using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject player;

    public float speed;

    public float detection_distance;

    public int health = 100;

    private float distance;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < detection_distance)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void Hit (int damage)
    {
        Debug.Log("ouch");
        health -= damage;
    }
}
