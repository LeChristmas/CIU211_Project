using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public bool isactive;

    public GameObject gun;

    public GameObject pickup_text;

    public GameObject reload_text;
    public Text ammunition_text;
    public int ammunition;
    private bool reloading;

    private bool firing;

    private Ray ray;

    private RaycastHit hit;

    public Animator fire_animation;

    // Use this for initialization
    void Start ()
    {
        if(isactive)
        {
            Pickup();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isactive)
        {
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.transform.gameObject.tag == "gun")
                {
                    pickup_text.SetActive(true);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Pickup();
                        Destroy(hit.transform.gameObject);
                    }
                }
                else
                {
                    pickup_text.SetActive(false);
                }

            }
        }

		if (Input.GetButtonDown("Fire1") && isactive && !firing && !reloading && ammunition > 0)
        {
            firing = true;
            StartCoroutine("Fire_Delay");
            Fire();
        }

        if(Input.GetKeyDown(KeyCode.R) && isactive && !reloading)
        {
            reloading = true;
            StartCoroutine("Reload");
        }

        ammunition_text.text = ammunition.ToString();

        if(ammunition < 3)
        {
            reload_text.SetActive(true);
        }
        else
        {
            reload_text.SetActive(false);
        }
	}

    IEnumerator Reload ()
    {
        yield return new WaitForSeconds(3.0f);
        reloading = false;
        ammunition = 10;
    }

    IEnumerator Fire_Delay ()
    {
        yield return new WaitForSeconds(1.0f);
        firing = false;
    }

    void Fire ()
    {
        ammunition--;
        if(ammunition == 0)
        {
            fire_animation.SetBool("Empty", true);
        }
        else
        {
            fire_animation.SetTrigger("Fire");
        }
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.gameObject.tag == "enemy")
            {
                Debug.Log("Hit");
                Enemy_AI enemey = hit.transform.gameObject.GetComponent<Enemy_AI>();
                enemey.Hit(25);
            }
            else
            {
                Debug.Log("Miss");
            }
        }
    }

    void Pickup ()
    {
        isactive = true;
        ammunition_text.enabled = true;
        gun.SetActive(true);
        pickup_text.SetActive(false);
    }
}
