using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent onFrogDeleted = new UnityEvent();
    public static UnityEvent onPlayerTakedDamage = new UnityEvent();
    public static UnityEvent onEndedHealth = new UnityEvent();
    public static UnityEvent<GameObject> onTouchedPlayer = new UnityEvent<GameObject>();
    
    public static void ScoringEvent()
    {
        onFrogDeleted?.Invoke();
    }

    public static void TakenAwayHealthEvent()
    {
        onPlayerTakedDamage?.Invoke();
    }

    public static void DefeatEvent()
    {
        onEndedHealth?.Invoke();
    }

    public static void DeletingFrog(GameObject touchedFrog)
    {
        onTouchedPlayer?.Invoke(touchedFrog);
    }
}
