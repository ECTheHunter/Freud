using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public bool IsDead { get; private set; }

    public void Die()
    {
        if (IsDead) return;

        OnPlayerDeath?.Invoke();
        IsDead = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blood")
        {
            Die();
        }
    }
}
