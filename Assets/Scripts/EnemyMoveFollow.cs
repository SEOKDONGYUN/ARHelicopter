using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //유니티에 내장된 AI 네비게이션 기능 사용

public class EnemyMoveFollow : MonoBehaviour
{
    Transform p;
    NavMeshAgent nav; //네비
    
    void Start()
    {
        p = GameObject.Find("Player").transform; //플레이어의 위치값을 찾기
        nav = GetComponent<NavMeshAgent>(); //내비메쉬에이전트 기능 가져오기
    }

    void Update()
    {
        if (GameManager.instance.isGameover || GameManager.instance.isStageclear)
        {
            nav.enabled = false;
        }
        
        if (nav.isActiveAndEnabled) //방어코딩, 내비가 켜져있을때
        {
            nav.SetDestination(p.position); //내비.목적지(플레이어.포지션), 플레이어에게 이동
            transform.LookAt(p);
        }

        
    }

}
