using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour, ISubject
{
    [SerializeField] public List<IObserver> observers = new List<IObserver>();
    public string questName;
    public string questDescription;

    public enum State { Active, Inactive, Complete}
    public State currentState;


    private void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        switch (currentState)
        {
            //notifies observers in case of change
            case State.Active:
                {
                    NotifyObserver(0);
                    break;
                }
            //unsubscribes every observer in case the quest is no longer in progress
            case State.Inactive:
                {
                    foreach (IObserver observer in observers)
                    {
                        UnregisterObserver(observer);
                    }
                    break;
                }
            //notifies observers when quest is completed
            case State.Complete:
                {
                    NotifyObserver(1);
                    break;
                }
        }
    }

    public void NotifyObserver(object parameter)
    {
       foreach(IObserver observer in observers)
       {
            observer.UpdateObserver(this, parameter);
       }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void ActivateQuest()
    {
        currentState = State.Active;
        NotifyObserver();
    }

    public void DeactivateQuest()
    {
        currentState = State.Inactive;
        NotifyObserver();
    }
}
