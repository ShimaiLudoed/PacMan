using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
  public event Action OnBonus;

  public void ActivateBonus()
  {
    OnBonus?.Invoke();
  }
}
