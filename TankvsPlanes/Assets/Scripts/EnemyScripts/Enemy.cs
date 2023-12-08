using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{


    public int maxHealth;
    public float speed;
    public float lifetime;
    public int bombAmount;
    public float bombDelay;
    public float bombCooldown;
  

    public GameObject bombPrefab; 
    private float lastBombTime; 
    private bool isBombing = false; 



    private bool isTakingDamage = false;
    private Color originalColor;
    public Color damageColor = Color.red; 
    public float damageDuration = 0.5f;


    public AudioClip hurtSound;
    private AudioSource audioSource;
    public GameObject destructionEffectPrefab;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        originalColor = GetComponent<SpriteRenderer>().color;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

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
        for (int i = 0; i < bombAmount; i++)
        {

           
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
