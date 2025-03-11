using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
  public class Radius : MonoBehaviour
  {
    [SerializeField] private LayerMask player;
    public event Action OnPlayerLeave;
    public event Action OnPlayerDetect;
    private void OnTriggerStay2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
      {
        OnPlayerDetect?.Invoke();
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
      {
        OnPlayerLeave?.Invoke();
      }
    }
  }
}
