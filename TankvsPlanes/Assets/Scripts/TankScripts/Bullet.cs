using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 3f;
    public float speed = 5f;


    private void Start()
    {
        Destroy(gameObject, lifetime);
    }


    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
 
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Dañar enemigo
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }


        if (collision.CompareTag("BalaEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
