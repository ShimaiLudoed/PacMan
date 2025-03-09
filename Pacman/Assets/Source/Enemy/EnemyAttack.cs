using Player;
using System;
using UnityEngine;

namespace Enemy
{
  public class EnemyAttack : MonoBehaviour
  {
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private LayerMask player;
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
      {
        playerHealth.TakeDamage();
      }
    }
  }
}
