using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    public bool isGameover = false;
    public bool isStageclear = false;
    
    public GameObject gameoverUI;
    public GameObject clearUI;
    public GameObject aimUI;
    
    public Text scoreText;
    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        aimUI.SetActive(false);
        gameoverUI.SetActive(true);
    }

    public void OnStageClear()
    {
        isStageclear = true;
        aimUI.SetActive(false);
        clearUI.SetActive(true);
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Kill : " + score + " / 100";
        }
    }
        
    void Start()
    {
    }

    void Update()
    {
        if (score == 100)
            OnStageClear();
    }
}
