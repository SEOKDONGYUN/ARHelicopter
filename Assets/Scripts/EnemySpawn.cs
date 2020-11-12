using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] tank;
    public float time;
    public float timetank;
    public Transform[] point;
    public Transform[] tankpoint;

    public int Max;
    public int count;

    int level = 0;

    void Create()
    {
        if (!GameManager.instance.isGameover)
        {

            if (count >= Max)
                return;

            count++;

            int i = Random.Range(0, point.Length); //랜덤.범위(0, 포인트[배열].길이)
            int j = Random.Range(0, obj.Length);

            Instantiate(obj[j], point[i]); //인스텐세이트(프리펩,위치값)

            if (level >= 1)
            {
                Levelup();
            }

            Invoke("Create", time);
        }
    }

    void TankCreate()
    {
        if (!GameManager.instance.isGameover)
        {

            if (count >= Max)
                return;

            count++;

            int i = Random.Range(0, tankpoint.Length); //랜덤.범위(0, 포인트[배열].길이)
            int j = Random.Range(0, tank.Length);

            Instantiate(tank[j], tankpoint[i]); //인스텐세이트(프리펩,위치값)

            if (level >= 2)
            {
                LevelupTank();
            }

            Invoke("TankCreate", timetank);
        }
    }

    void Start()
    {
        Invoke("Create", 2);
        Invoke("TankCreate", timetank + 10f);
        //InvokeRepeating("Create", time, time); //기달렸다가 호출, 시작하고 ~초 지나고 나서 부르고, ~초마다 실행
    }

    void Update()
    {
        if (count >= 50)
        {
            level = 1;
        }
        if (count >= 70)
        {
            level = 2;
        }
    }

    void Levelup()
    {
        time = 2f;
    }

    void LevelupTank()
    {
        timetank = 10f;
    }
}
