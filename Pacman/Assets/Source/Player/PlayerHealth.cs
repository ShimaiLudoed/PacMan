using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void ReduceLife()
    {
        _currentHealth--;
        if(_currentHealth == 0 )
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject); 
    }
}
