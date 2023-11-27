using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gameState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void YouLose()
    {
        SceneManager.LoadScene(0);

        gameState = 2;
    }

    public void YouWin()
    {
        SceneManager.LoadScene(0);

        gameState = 1;
    }
}
