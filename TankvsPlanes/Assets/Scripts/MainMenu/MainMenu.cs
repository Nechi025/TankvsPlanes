using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectMenu;
    public GameObject win;
    public GameObject lose;

    [SerializeField] private AudioClip switchSelect;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mainMenu.activeSelf == true)
            {
                mainMenu.SetActive(false);
                selectMenu.SetActive(true);
            }

            else if (win.activeSelf == true)
            {
                win.SetActive(false);
                mainMenu.SetActive(true);
                Cursor.visible = true;
            }

            else if (lose.activeSelf == true)
            {
                lose.SetActive(false);
                mainMenu.SetActive(true);
                Cursor.visible = true;
            }
        }

        if (GameManager.instance.gameState == 1)
        {
            mainMenu.SetActive(false);
            win.SetActive(true);
            GameManager.instance.gameState = 0;

        }

        if (GameManager.instance.gameState == 2)
        {
            mainMenu.SetActive(false);
            lose.SetActive(true);
            GameManager.instance.gameState = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
