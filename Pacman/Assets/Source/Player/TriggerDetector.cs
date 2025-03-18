using Enemy;
using System;
using UnityEngine;

namespace Player
{
  public class TriggerDetector : MonoBehaviour
  {
    private EnemyHealth _enemyHealth;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask scorePointLayer;
    [SerializeField] private LayerMask bonusLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(bonusLayer, other.gameObject.layer))
      {
        playerHealth.IsDamage = false;
      }

      if (LayerMaskCheck.ContainsLayer(enemyLayer, other.gameObject.layer))
      {
        if (playerHealth.IsDamage == true)
        {
          playerHealth.TakeDamage();
        }
        else
        {
          _enemyHealth = other.GetComponent<EnemyHealth>();
          playerScore.Attack();
          _enemyHealth.Die();
        }
      }

      if (LayerMaskCheck.ContainsLayer(scorePointLayer, other.gameObject.layer))
      {
        Destroy(other.gameObject);
        playerScore.AddScore();
      }
    }
  }
}
