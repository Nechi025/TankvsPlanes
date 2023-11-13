using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform objetoAEmular;
    public float maxAngle = 60f;
    public float minAngle = -60f;


    private void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calcular el ángulo entre la dirección actual del cañón y la dirección del mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Limitar el ángulo entre los valores deseados
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Aplicar la rotación al cañón
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Mantener la posición del objeto a emular
        transform.position = objetoAEmular.position;
    }
}