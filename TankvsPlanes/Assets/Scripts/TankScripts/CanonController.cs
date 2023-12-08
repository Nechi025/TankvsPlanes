using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform firePoint;


    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float timeBtwShots = 1;
    private float timeOfLastShot;


    
    public GameObject altBulletPrefab;
    public float altBulletSpeed = 10f;
    public float altTimeBtwShots = 1;
    private float altTimeOfLastShot;


    private GameObject tanqueCuerpo;
    private SpriteRenderer tanqueCuerpoRenderer;


    private float minRotation = -90f;
    public float rotationSpeed = 5f;


    private int fire1 = 0;
    public float timeBtwChange = 3;
    private float timeLastChange;

    void Start()
    {
        Cursor.visible = false;

        tanqueCuerpo = transform.parent.gameObject;
        tanqueCuerpoRenderer = tanqueCuerpo.GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        Aim();

        


        if (Input.GetButton("Fire1")) 
        {
            if (fire1 == 0)
            {
                Shoot();
            }
            else
            {
                ShootAlt();
            }

        }

        if (Input.GetButtonDown("Fire2"))
        {
            
            if (Time.time - timeLastChange >= timeBtwChange)
            {
                ChangeBulletType();
                timeLastChange = Time.time;
            }

        }

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

    void ChangeBulletType()
    {

        if (fire1 == 0)
        { 
        fire1 = 1;
        
        }

        else if(fire1 == 1)
        {
            fire1 = 0;
           

        }
        
    }



    void Shoot()
    {
        if (Time.time - timeOfLastShot >= timeBtwShots)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            timeOfLastShot = Time.time;
        }
    }



    void ShootAlt()
    {
        if (Time.time - altTimeOfLastShot >= altTimeBtwShots)
        {
            GameObject bullet = Instantiate(altBulletPrefab, firePoint.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(transform.up * altBulletSpeed, ForceMode2D.Impulse);
            altTimeOfLastShot = Time.time;
        }
    }



}