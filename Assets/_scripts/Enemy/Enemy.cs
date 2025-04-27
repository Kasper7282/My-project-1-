using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDeath;
    [SerializeField] protected EnemyData enemyData;
    private float currentHealth;

    protected virtual void Awake()
    {
        if (enemyData != null)
        {
            currentHealth = enemyData.maxHealth;
        }
        else
        {
            Debug.LogError("Enemy Data not assigned to " + gameObject.name);
        }
    }

    public virtual void Die()
    {
        Debug.Log($"'{enemyData.enemyName} is dying'");
        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
    }

    public virtual void GetDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{enemyData.enemyName} got {damage} damage and health now is {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetEnemyData(EnemyData data)
    {
        enemyData = data;
        currentHealth = enemyData.maxHealth;
    }
}
