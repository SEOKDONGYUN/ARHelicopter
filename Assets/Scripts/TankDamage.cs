using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankDamage : MonoBehaviour
{
    public GameObject smoke;
    public AudioSource exsound;

    public void ExDamage()
    {
        if (!GameManager.instance.isGameover)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            gameObject.layer = 0;

            //GetComponent<BoxCollider>().enabled = false;

            smoke.SetActive(true);

            Destroy(gameObject, 4f);

            exsound.Play();

            GameManager.instance.AddScore(1);
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
