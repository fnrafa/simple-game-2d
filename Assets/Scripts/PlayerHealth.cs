using UnityEngine.SceneManagement;

public class PlayerHealth : PlayerInit
{
    private static readonly int MaxHealth = 5;

    public static void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            PlayerDeath();
        }
    }

    private static void PlayerDeath()
    {
        GameManager.ResetFruits();
        SceneManager.LoadScene("MainMenu");
        health = MaxHealth;
    }
}