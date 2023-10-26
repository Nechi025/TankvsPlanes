using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform objetoAEmular;

    private void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));

        Vector3 direction = (mousePosition - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.rotation = rotation;

        transform.position = objetoAEmular.position;
    }
}