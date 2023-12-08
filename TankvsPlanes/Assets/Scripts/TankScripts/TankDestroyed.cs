using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroyed : MonoBehaviour
{

    public float animlife = 5f;

    private void Update()
    {

        animlife -= Time.deltaTime;


        if (animlife <= 0)
        {

            StartCoroutine(RestartGame());

        }

    }


    IEnumerator RestartGame()
    {
        GameManager.instance.YouLose();

        yield return new WaitForSeconds(0.2f);

        PlayerController.Destroy(gameObject);

    }
}
