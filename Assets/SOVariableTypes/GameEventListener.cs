using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour // attached to game objects in the scene that need to react to a certain event happening
{
    [SerializeField] private GameEvent gameEvent; // the modular game event that the listener is subscribed to
    [SerializeField] private UnityEvent response; // specify what functions a given listener invokes when the event occurs
    
    public void OnEventRaised()
    {
        response?.Invoke(); // if there is at least one response function specified then start the function(s)
    }

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }
}
