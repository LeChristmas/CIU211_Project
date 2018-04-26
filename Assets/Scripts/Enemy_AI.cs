using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject player;

    public Transform linecast_target;

    public Animator attack_arm;

    public float speed;

    public float detection_distance;

    public int health = 100;

    public float attack_damage = 10.0f;

    public GameObject highlight;

    private float distance;

    private bool damaged;

    private RaycastHit hit;

    private bool rotating_lock;

    private bool death;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < detection_distance && distance > 1.29f)
        {
            transform.LookAt(player.transform);

            if (Physics.Linecast(transform.position, linecast_target.position, out hit))
            {
                Debug.Log("Blocked by: " + hit.transform.gameObject);
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }
        }

        if(damaged)
        {
            transform.LookAt(player.transform);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        if (distance < 1.3f)
        {
            Debug.Log("Attacking");
            attack_arm.SetTrigger("Attack"); 
            player.GetComponent<Player_Health>().Attacked(attack_damage);
        }

        if (health <= 0)
        {
            if(!death)
            {
                death = true;
                player.GetComponent<Collectibles>().enemies_killed++;
            }
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            StartCoroutine(Death_Delay());
        }
	}

    public void Hit (int damage)
    {
        if(!damaged)
        {
            damaged = true;
            highlight.SetActive(true);
            StartCoroutine("No_Damage");
            health -= damage;
        }
    }

    IEnumerator No_Damage ()
    {
        yield return new WaitForSeconds(0.5f);
        damaged = false;
        highlight.SetActive(false);
    }

    IEnumerator Death_Delay ()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
