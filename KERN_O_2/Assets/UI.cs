using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour, IObserver
{
    private void Start()
    {
        Quest[] quest = FindObjectsOfType<Quest>(); 
        foreach(Quest q in quest)
        {
            q.RegisterObserver(this);
        }
    }

    public void UpdateObserver(ISubject subject, object parameter)
    {
        if (subject is Quest quest)
        {
            if(parameter.Equals(0))
            {
                Debug.Log("Show Quest Progress");
                UpdateUI(quest);
            }
            
            //unsubscribe when quest is completed
            if (parameter.Equals(1))
            {
                Debug.Log("Show Quest Progress");
                UpdateUI(quest);
                subject.UnregisterObserver(this);
            }
        }
    }

    void UpdateUI(Quest quest)
    {
        Debug.Log(quest.currentState);
        Debug.Log(quest.questName);
        Debug.Log(quest.questDescription);
    }
}
