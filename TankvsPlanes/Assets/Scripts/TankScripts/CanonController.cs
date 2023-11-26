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

    private GameObject tanqueCuerpo;
    private SpriteRenderer tanqueCuerpoRenderer;

    public float rotationSpeed = 5f;

    void Start()
    {
        Cursor.visible = false;

        tanqueCuerpo = transform.parent.gameObject;
        tanqueCuerpoRenderer = tanqueCuerpo.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Aim();
        Shoot();

        GetComponent<SpriteRenderer>().color = tanqueCuerpoRenderer.color;
    }

    void Aim()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));

        Vector3 direction = (mousePosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        targetAngle = Mathf.Clamp(targetAngle, minRotation, 90f);

        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
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