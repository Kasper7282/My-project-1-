using UnityEngine;

public class BobrittoBandito : Enemy
{
    [SerializeField] private GameObject bombPrefab;

    public override void Die()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        
        base.Die();
    }
}