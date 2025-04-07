using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerpositon;
    public static GameManager Instance {get; private set;}
    private enum GameState
    {
        GameOver,
        Clear
    }
    public event Action OnGameOver;
    public event Action OffGameOver;

    private GameState state;
        void Awake()
    {
        if(Instance == null)
        {
        Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);    
    }
    


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerpositon = player.transform.position;

        OnGameOver += UIManager.Instance.ShowGameOverUI;
        OffGameOver += UIManager.Instance.HideGameOverUI;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
           Restart();
           Debug.Log("게임 재시작");
           OffGameOver?.Invoke();
        }
    }

    void Restart()
    {
        Time.timeScale = 1f;
        player.gameObject.SetActive(true);
        player.transform.position = playerpositon;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void GameOver()
    {
        state = GameState.GameOver;
        OnGameOver?.Invoke();
    }

    public void GameClear()
    {
        state = GameState.Clear;
        UIManager.Instance.ShowClearUI();
    }
}
