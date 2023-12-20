using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameEvent", menuName = "Variable/GameEvent")]
public class GameEvent : ScriptableObject // used to modularise game events to reduce hard references
{
    private List<GameEventListener> listeners = new List<GameEventListener>(); // keeps track of what game objects are waiting to act when this event is triggered

    public void Raise() // go through all listeners and trigger their response to the event occurring
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener) // used by listeners to sign themselves up for notifications when the event occurs
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) // used by listeners to remove themselves from receiving notifications when the event occurs
    {
        listeners.Remove(listener);
    }
}
