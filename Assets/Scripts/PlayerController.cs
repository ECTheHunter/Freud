using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public bool IsDead { get; private set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Die()
    {
        if (IsDead) return;

        OnPlayerDeath?.Invoke();
        IsDead = true;
    }
}
