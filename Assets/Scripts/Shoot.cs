using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    public GameObject cam;
    public GameObject smoke;
    public GameObject gunshoot;

    public void Fire()
    {
        if (!GameManager.instance.isGameover)
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "Enemy" ||
                    hit.transform.name == "balloon1(Clone)" ||
                    hit.transform.name == "balloon2(Clone)" ||
                    hit.transform.name == "balloon3(Clone)")
                {
                    EnemyDamage e = hit.collider.GetComponent<EnemyDamage>();

                    e.Damage();

                    //Destroy(hit.transform.gameObject, 2f);
                    Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else
                {
                    Instantiate(gunshoot, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
