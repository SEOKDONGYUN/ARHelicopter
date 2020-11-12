using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;
    
    void Start()
    {
        StartCoroutine(StartSpawning());    // 동시실행함수
    }

    IEnumerator StartSpawning() // 스타트코루틴에 쓰이는 틀
    {
        yield return new WaitForSeconds(4); // 일드 리턴도 필요

        for(int i = 0; i<3; i++)
        {
            Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
        }

        StartCoroutine(StartSpawning());
    }

    void Update()
    {
        
    }
}
