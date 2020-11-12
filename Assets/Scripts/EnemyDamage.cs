using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    public AudioSource deathsound;

    public void Damage()
    {
        if (!GameManager.instance.isGameover)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            gameObject.layer = 0;

            GetComponent<CapsuleCollider>().enabled = false;

            Destroy(gameObject, 2f);

            GetComponent<Animator>().SetTrigger("tDeath");

            GameManager.instance.AddScore(1);
        }
    }

    public void ExDamage()
    {
        if (!GameManager.instance.isGameover)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            gameObject.layer = 0;

            //GetComponent<CapsuleCollider>().enabled = false;

            Destroy(gameObject, 2f);

            GetComponent<Animator>().SetTrigger("tDeath");

            deathsound.Play();

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
