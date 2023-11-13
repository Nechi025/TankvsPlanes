using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public int damage = 10; // Daño
    public float initialSpeed = 2f; // IVelocidad incial
    public float timeToAcceleration = 2f; // Tiempo de aceleracion
    public float acceleratedSpeed = 5f; // Velocidad de aceleracion
    public float lifetime = 20f; // Tiempo de vida

    private Rigidbody2D rb;
    private float accelerationTimer = 0f;
    private bool hasAccelerated = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Velocidad para abajo
        rb.velocity = -transform.up * initialSpeed;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Contador de acceleracion
        accelerationTimer += Time.deltaTime;

        // Cuando pueda acelerar
        if (!hasAccelerated && accelerationTimer >= timeToAcceleration)
        {
            // el misil se acelera
            rb.velocity = -transform.up * acceleratedSpeed;
            hasAccelerated = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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


        if (collision.CompareTag("Bala"))
        {
            // Chau Bomba
            Destroy(this.gameObject);
        }



    }
}
