using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserverable
{
    public void AddListener(IObserver observer);
    public void RemoveListener(IObserver observer);
    public void Notify();
}