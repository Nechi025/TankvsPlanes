using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; //Vida Jugador
    private int currentHealth; //Vida actual de jugador

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
        originalColor = GetComponent<SpriteRenderer>().color;

    }

    private void Update()
    {
        // Fijarse que la vida de jugador este arriba de 0
        if (currentHealth <= 0)
        {
            //Resetear juego si se muere
            RestartGame();
        }
    }

    // Aplicar daño al jugador
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

            // Change the color to the damage color
            GetComponent<SpriteRenderer>().color = damageColor;

            // Wait for the damage duration
            yield return new WaitForSeconds(damageDuration);

            // Restore the original color
            GetComponent<SpriteRenderer>().color = originalColor;

            isTakingDamage = false;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    private void RestartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}