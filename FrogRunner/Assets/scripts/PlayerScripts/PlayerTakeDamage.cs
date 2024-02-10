using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EventManager.TakenAwayHealthEvent();
            EventManager.DeletingFrog(other.gameObject);
        }
    }
}
