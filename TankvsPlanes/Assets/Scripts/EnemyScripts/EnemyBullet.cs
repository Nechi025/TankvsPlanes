using UnityEngine;

public class EnemyBullet : MonoBehaviour, ICollision
{
    public float bulletSpeed = 5f; // Velocidad
    public int damage = 1; // Daño de bala
    public float lifetime = 3f; // Tiempo de vida

    private Vector3 targetPosition; // Posicion del jugador
    private float currentLifetime; // Tiempo de vida actual
    private Vector3 moveDirection; // Direccion de movimiento

    private void Start()
    {
        currentLifetime = lifetime;

        // Buscar la posicion del jugador cuando se genera la bala
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetPosition = player.transform.position;
            moveDirection = (targetPosition - transform.position).normalized;
        }

    }

    private void Update()
    {
        // Seguir la direccion de la bala
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime, Space.World);

        // Tiempo de Vida
        currentLifetime -= Time.deltaTime;

        // Rotar el sprite
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // se destruye la bala si se acaba el tiempo de vida
        if (currentLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Colosion con jugador
        if (collision.CompareTag("Player"))
        {

            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                //Hacer daño al jugador
                player.TakeDamage(damage);
            }

            // se destruye
            Destroy(gameObject);
        }
    }
}
