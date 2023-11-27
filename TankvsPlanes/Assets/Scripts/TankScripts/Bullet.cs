using UnityEngine;

public class Bullet : MonoBehaviour, ICollision
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

    public void OnTriggerEnter2D(Collider2D collision)
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

        if (collision.CompareTag("Boss"))
        {

            BossFight boss = collision.GetComponent<BossFight>();

            if (boss != null)
            {
                // Daño Jefe
                boss.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("BalaEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
