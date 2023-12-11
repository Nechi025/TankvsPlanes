using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 0)]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public float speed;
    public float lifetime;
    public int bombAmount;
    public float bombDelay;
    public float bombCooldown;
}
