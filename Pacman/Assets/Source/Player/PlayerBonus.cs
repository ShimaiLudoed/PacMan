using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : IObserverable
{
  public bool IsBonusActive;
  private List<IObserver> _observers;

  public PlayerBonus(List<IObserver> observers)
  {
    _observers = observers;
  }
  
  public void AddListener(IObserver observer)
  {
    _observers.Add(observer);
  }

  public void RemoveListener(IObserver observer)
  {
    _observers.Remove(observer);
  }

  public void Notify()
  {
    foreach (var observer in _observers)
    {
      observer.Update(IsBonusActive);
    }
  }

  public void Update()
  {
   Notify(); 
  }
}
