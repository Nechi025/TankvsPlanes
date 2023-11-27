using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BossFight : MonoBehaviour, IDamageable
{
    public GameObject boss;
    public Transform[] attackOrigins;
    public GameObject[] projectiles;
    public float moveSpeed = 2f;
    public float attackCooldown = 2f;
    public int bossMaxHealth = 100;
    public int bossCurrentHealth;

    private bool isAttacking = false;
    private Transform target;

    private bool isMovingLeft = true;

    private bool isTakingDamage = false;
    private Color originalColor;
    public Color damageColor = Color.red;
    public float damageDuration = 0.5f;

    public AudioClip hurtSound;
    private AudioSource audioSource;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(AttackSequence());
        originalColor = GetComponent<SpriteRenderer>().color;
        audioSource = GetComponent<AudioSource>();
        bossCurrentHealth = bossMaxHealth;
    }

    private void Update()
    {
        // Se mueve de izquierda a derecha
        if (isMovingLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }


        if (transform.position.x < -5f)
        {
            isMovingLeft = false;
        }
        else if (transform.position.x > 5f)
        {
            isMovingLeft = true;
        }
    }


    private IEnumerator AttackSequence()
    {
        while (true)
        {
            if (!isAttacking)
            {
                isAttacking = true;


                yield return new WaitForSeconds(attackCooldown);


                if (projectiles.Length > 0)
                {
                    int randomIndex = Random.Range(0, projectiles.Length);
                    GameObject selectedProjectile = projectiles[randomIndex];


                    LaunchProjectile(selectedProjectile);
                }

                isAttacking = false;
            }

            yield return null;
        }
    }

    private void LaunchProjectile(GameObject projectilePrefab)
    {
        if (boss != null && target != null)
        {

            Transform origin = attackOrigins[Random.Range(0, attackOrigins.Length)];


            GameObject attack = Instantiate(projectilePrefab, origin.position, Quaternion.identity);

        }
    }

    public void TakeDamage(int damage)
    {
        bossCurrentHealth -= damage;
        StartCoroutine(ShowDamageIndicator());
        // Primer fase derrotada
        if (bossCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        PlayHurtSound();
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
