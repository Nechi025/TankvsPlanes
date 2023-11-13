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

    // Texto de vida
    public Text healthText;

    private void Start()
    {
        currentHealth = maxHealth;
        playerCollider = GetComponent<Collider2D>();


        if (healthText != null)
        {
            UpdateHealthText();
        }
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

        // Actualizar Texto
        UpdateHealthText();
    }



    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    // Actualizar el texto de vida
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    //
    private void RestartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
