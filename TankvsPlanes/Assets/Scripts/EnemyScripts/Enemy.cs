using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{


    public int maxHealth;
    public float speed;
    public float lifetime;
    public int bombAmount; //Cantidad de Bombas que tira en un "Bombing Run"
    public float bombDelay;//Tiempo entre el tiro de bombas del "Bombing Run"
    public float bombCooldown;//Cooldwon entre los "Bombing run"

    //Ej: un enemigo con un bombAmount de 3, Delay de 0.2 y cooldown de 10, tiraria 3 bombas con un intervalo de 0.2seg entre cada una pero despues tendria que esperar 10seg para tirar las sig 3 bombas


    public GameObject bombPrefab; // Prefab de Bomba
    private float lastBombTime; 
    private bool isBombing = false; 



    private bool isTakingDamage = false;
    private Color originalColor;
    public Color damageColor = Color.red; 
    public float damageDuration = 0.5f;

    public AudioClip hurtSound;
    private AudioSource audioSource;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        originalColor = GetComponent<SpriteRenderer>().color;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Solo se mueven a la izquierda
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Fijares si se puede tirar bombas
        if (!isBombing && Time.time - lastBombTime >= bombCooldown)
        {
            StartBombing();
        }



    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
    
        StartCoroutine(ShowDamageIndicator());
        
        if (maxHealth <= 0)
        {
            // Destruir
            Destroy(gameObject);
        }
        PlayHurtSound();

    }


    //Bombing se refiere a la cantidad de bombas seguidas que se pueden tirar entre intervalos

    private void StartBombing()
    {
        isBombing = true;
        StartCoroutine(DropBombs());
    }

    private IEnumerator DropBombs()
    {
        for (int i = 0; i < bombAmount; i++)
        {
            // Crear la bomba
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(bombDelay);



        }

        isBombing = false;
        lastBombTime = Time.time;
    }


    private IEnumerator ShowDamageIndicator()
    {
        if (!isTakingDamage)
        {
            isTakingDamage = true;

            // Change the color to the damage color
            GetComponent<SpriteRenderer>().color = damageColor;

            // Wait for the damage duration
            yield return new WaitForSeconds(damageDuration);

            // Restore the original color
            GetComponent<SpriteRenderer>().color = originalColor;

            isTakingDamage = false;
        }
    }


    private void PlayHurtSound()
    {
        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }
}
