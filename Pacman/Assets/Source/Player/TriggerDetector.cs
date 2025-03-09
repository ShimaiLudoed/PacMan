using UnityEngine;

namespace Player
{
  public class TriggerDetector : MonoBehaviour
  {
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private LayerMask scorePoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
      {
        playerHealth.TakeDamage();
      }
      if (LayerMaskCheck.ContainsLayer(scorePoint, other.gameObject.layer))
      {
        Destroy(other.gameObject);
        playerScore.AddScore();
      }
    }
  }
}
