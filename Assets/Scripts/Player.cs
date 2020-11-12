using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosion;

    void Start()
    {
        
    }

     void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Tank")
        {
            Debug.Log("GameOver");

            explosion.SetActive(true);

            GameManager.instance.OnPlayerDead();
        }
    }

}
