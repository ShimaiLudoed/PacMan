using Enemy;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float pauseDuration = 1f;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private TriggerDetector triggerDetector;

    private void Start()
    {
        transform.position = startPosition;
        triggerDetector.OnPlayerDamaged += TakeDamage;
    }
    public void Die()
    {
        _enemy.GoHome();
        _enemy.GetComponent<Collider2D>().enabled = false;
    }
    public void TakeDamage()
    {
        StartCoroutine(Take());
    }

    public IEnumerator Take()
    {
        yield return new WaitForSeconds(pauseDuration);
        transform.position = startPosition;

    }
}
