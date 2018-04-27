using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public Image[] collectible_icons;

    public GameObject pickup_text;

    public int enemies_killed;

    private Ray ray;
    private RaycastHit hit;

    public bool gunactive;

    public int collectible_number = 0;

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.transform.gameObject.tag == "Collectible")
            {
                pickup_text.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject collectible = hit.transform.gameObject;
                    collectible_icons[collectible_number].color = collectible.GetComponent<Renderer>().material.color;
                    collectible_number++;
                    Destroy(collectible);
                    collectible = null;
                }

            }
            else
            {
                pickup_text.SetActive(false);
            }
        }

    }
}
