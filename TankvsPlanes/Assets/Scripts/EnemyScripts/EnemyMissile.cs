using UnityEngine;

public class EnemyMissile : MonoBehaviour, ICollision
{
    public int damage = 25; 
    public float initialSpeed = 2f; 
    public float timeToAcceleration = 2f; 
    public float acceleratedSpeed = 5f; 
    public float lifetime = 5f; 

    private Rigidbody2D rb;
    private float accelerationTimer = 0f;
    private bool hasAccelerated = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        rb.velocity = -transform.up * initialSpeed;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        
        accelerationTimer += Time.deltaTime;
        
        if (!hasAccelerated && accelerationTimer >= timeToAcceleration)
        {
            
            rb.velocity = -transform.up * acceleratedSpeed;
            hasAccelerated = true;
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


        if (collision.CompareTag("Bala"))
        {
          
            Destroy(this.gameObject);
        }


    }
}
