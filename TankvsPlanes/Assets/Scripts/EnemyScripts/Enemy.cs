using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{


    public EnemyStats enemyStats;
    private int currentHealth;

    public GameObject bombPrefab; 
    private float lastBombTime; 
    private bool isBombing = false; 



    private bool isTakingDamage = false;
    private Color originalColor;
    public Color damageColor = Color.red; 
    private float damageDuration = 0.2f;


    public AudioClip hurtSound;
    private AudioSource audioSource;
    public GameObject destructionEffectPrefab;

    private void Start()
    {
        Destroy(gameObject, enemyStats.lifetime);
        originalColor = GetComponent<SpriteRenderer>().color;
        audioSource = GetComponent<AudioSource>();
        currentHealth = enemyStats.maxHealth;
    }

    private void Update()
    {

        transform.Translate(Vector2.right * enemyStats.speed * Time.deltaTime);

        if (!isBombing && Time.time - lastBombTime >= enemyStats.bombCooldown)
        {
            StartBombing();
        }



    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
    

        StartCoroutine(ShowDamageIndicator());
        

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            if (destructionEffectPrefab != null)
            {
                Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity);
            }


        }
        PlayHurtSound();

    }




    private void StartBombing()
    {

        isBombing = true;

        StartCoroutine(DropBombs());

    }



    private IEnumerator DropBombs()
    {
        for (int i = 0; i < enemyStats.bombAmount; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(enemyStats.bombDelay);
        }

        isBombing = false;
        lastBombTime = Time.time;
    }


    private IEnumerator ShowDamageIndicator()
    {


        if (!isTakingDamage)
        {


            isTakingDamage = true;
            GetComponent<SpriteRenderer>().color = damageColor;

           
            yield return new WaitForSeconds(damageDuration);

           
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
