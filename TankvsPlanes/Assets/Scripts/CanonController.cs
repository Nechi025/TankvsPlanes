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

        // Calcular el �ngulo entre la direcci�n actual del ca��n y la direcci�n del mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Limitar el �ngulo entre los valores deseados
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Aplicar la rotaci�n al ca��n
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Mantener la posici�n del objeto a emular
        transform.position = objetoAEmular.position;
    }
}