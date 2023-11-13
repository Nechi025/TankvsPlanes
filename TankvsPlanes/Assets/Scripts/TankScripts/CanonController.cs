using System.Collections;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float timeBtwShots = 1;
    private float timeOfLastShot;
    private float minRotation = -90f;

    void Start()
    {

        Cursor.visible = false;
    }

    private void Update()
    {
        Aim();
        Shoot();
    }

    void Aim()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle -= 90f;

        angle = Mathf.Clamp(angle, minRotation, 90f);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = rotation;
    }


    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - timeOfLastShot >= timeBtwShots) // Cooldown de tiro
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
                timeOfLastShot = Time.time;
            }
        }
    }
}
