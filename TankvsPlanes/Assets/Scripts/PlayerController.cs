using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f; // Velocidad
    public float acceleration = 10.0f; // Aceleracion

    private float currentSpeed = 0.0f;
    private float targetSpeed = 0.0f;

    private void Update()
    {
        // Input de teclas A y D
        float horizontalInput = Input.GetAxis("Horizontal");

        //Calucar Velocidad
        targetSpeed = horizontalInput * moveSpeed;

        // Aplicar aceleracion
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);


        Vector3 newPosition = transform.position + new Vector3(currentSpeed * Time.deltaTime, 0f, 0f);


        transform.position = newPosition;
    }
}