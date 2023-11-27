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
    public GameObject selected;
    private int index = 1;

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

            else if (selectMenu.activeSelf == true && index == 0)
            {
                SceneManager.LoadScene(1);
            }

            else if (selectMenu.activeSelf == true && index == 5)
            {
                Application.Quit();
            }

            else if (win.activeSelf == true)
            {
                win.SetActive(false);
                mainMenu.SetActive(true);
            }

            else if (lose.activeSelf == true)
            {
                lose.SetActive(false);
                mainMenu.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.S) && index < 5 && selectMenu.activeSelf == true)
        {
            index++;
            SoundManager.Instance.playSound(switchSelect);
        }

        if (Input.GetKeyDown(KeyCode.W) && index > 0 && selectMenu.activeSelf == true)
        {
            index--;
            SoundManager.Instance.playSound(switchSelect);
        }

        switch (index)
        {
            case 0:
                selected.transform.position = new Vector3(760, 590, 0);
                break;
            case 1:
                selected.transform.position = new Vector3(760, 490, 0);
                break;
            case 2:
                selected.transform.position = new Vector3(760, 390, 0);
                break;
            case 3:
                selected.transform.position = new Vector3(760, 320, 0);
                break;
            case 4:
                selected.transform.position = new Vector3(760, 220, 0);
                break;
            case 5:
                selected.transform.position = new Vector3(760, 150, 0);
                break;
        }
    }
}
