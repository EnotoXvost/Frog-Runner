using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    private void Awake()
    {
        EventManager.onPlayerTakedDamage.AddListener(RemoveHealth);
    }
    private void Update()
    {
        if (_health <= 0)
        {
            EventManager.DefeatEvent();
        }
    }
    private void RemoveHealth()
    {
        _health--;
    }
    public int HealthShare()
    {
        return _health;
    }
}
