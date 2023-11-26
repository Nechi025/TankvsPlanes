using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; //Vida Jugador
    public int currentHealth; //Vida actual de jugador
    [SerializeField] private SpriteRenderer lifeSprite;

    [SerializeField] private Sprite sprite100;
    [SerializeField] private Sprite sprite75;
    [SerializeField] private Sprite sprite50;
    [SerializeField] private Sprite sprite25;
    [SerializeField] private Sprite sprite0;

    //Collider del jugador
    private Collider2D playerCollider;


    private bool isTakingDamage = false;
    private Color originalColor;
    public Color damageColor = Color.red; // Adjust the damage color
    public float damageDuration = 0.5f;

    private void Start()
    {
        currentHealth = maxHealth;
        playerCollider = GetComponent<Collider2D>();
        
        lifeSprite = lifeSprite.GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().color;

    }

    private void Update()
    {
        // Fijarse que la vida de jugador este arriba de 0
        if (currentHealth <= 0)
        {
            //Resetear juego si se muere

            StartCoroutine(RestartGame());
        }

        if (currentHealth == 100)
        {
            lifeSprite.sprite = sprite100;
        }
        else if (currentHealth == 75)
        {
            lifeSprite.sprite = sprite75;
        }
        else if (currentHealth == 50)
        {
            lifeSprite.sprite = sprite50;
        }
        else if (currentHealth == 25)
        {
            lifeSprite.sprite = sprite25;
        }
        else if (currentHealth == 0)
        {
            lifeSprite.sprite = sprite0;
        }
    }

    // Aplicar da�o al jugador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(ShowDamageIndicator());

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

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    IEnumerator RestartGame()
    {
        PlayerController.Destroy(gameObject);

        yield return new WaitForSeconds(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}