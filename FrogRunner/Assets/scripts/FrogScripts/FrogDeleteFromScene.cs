using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeleteFromScene : MonoBehaviour
{
    [SerializeField] private float _deletedZonePosition = -15f;

    private void Awake()
    {
        EventManager.onTouchedPlayer.AddListener(DeleteTouchedFrog);
    }

    private void Update()
    {
        DeleteDodgedFrog();
    }

    private void DeleteTouchedFrog(GameObject frog)
    {
        Destroy(frog);
    }

    private void DeleteDodgedFrog()
    {
        if (transform.position.z <= _deletedZonePosition)
        {
            Destroy(gameObject);
            EventManager.ScoringEvent();
        }
    }

    public float DeletedZonePositionShare()
    {
        return _deletedZonePosition;
    }
}
