using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectMenu;
    public GameObject selected;
    private int index = 1;

    [SerializeField] private AudioClip switchSelect;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (gameObject.activeSelf == true)
            {
                mainMenu.SetActive(false);
                selectMenu.SetActive(true);
            }

            if (selectMenu.activeSelf == true && index == 0)
            {
                SceneManager.LoadScene(1);
            }

            if (selectMenu.activeSelf == true && index == 5)
            {
                Application.Quit();
            }
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
