using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] private EnemyMove _enemy;

  public void Die()
  {
    _enemy.GoHome();
    _enemy.GetComponent<Collider2D>().enabled = false;
  }
}
