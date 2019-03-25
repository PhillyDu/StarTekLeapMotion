using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Shooting : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
