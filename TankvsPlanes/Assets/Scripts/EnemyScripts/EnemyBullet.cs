using UnityEngine;

public class EnemyBullet : MonoBehaviour, ICollision
{
    public float bulletSpeed = 5f; 
    public int damage = 1;
    public float lifetime = 3f;

    private Vector3 targetPosition;  
    private Vector3 moveDirection; 

    private void Start()
    {
        Destroy(gameObject, lifetime);


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

        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

       
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
        else if (collision.CompareTag("BalaDebil"))
        {
            
            Destroy(this.gameObject);

        }



    }

}
