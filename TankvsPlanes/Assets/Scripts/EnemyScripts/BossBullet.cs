using UnityEngine;

public class BossBullet : MonoBehaviour, ICollision
{
    public float bulletSpeed = 5f;
    public int damage = 1;
    public float lifetime = 3f;

    private Vector3 targetPosition;
    private float currentLifetime;
    private Vector3 moveDirection;

    private void Start()
    {
        currentLifetime = lifetime;


        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetPosition = player.transform.position;
            moveDirection = (targetPosition - transform.position).normalized;
        }

    }

    private void Update()
    {

        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime, Space.World);


        currentLifetime -= Time.deltaTime;


        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


        if (currentLifetime <= 0f)
        {

            Destroy(gameObject);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {


            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {

                player.TakeDamage(damage);

            }


            Destroy(gameObject);
        }


     

    }

}
