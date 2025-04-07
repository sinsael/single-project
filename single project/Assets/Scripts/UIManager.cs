using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; set;}

    public GameObject GameClearUI;
    public GameObject GameOverUI;

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

    public void ShowGameOverUI()
    {
        Debug.Log("게임 오버");
        GameOverUI.SetActive(true);
    }
    public void ShowClearUI()
    {
        GameClearUI.SetActive(true);
    }
    public void HideGameOverUI()
    {
        GameOverUI.SetActive(false);
    }
}
