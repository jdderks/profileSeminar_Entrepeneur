using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour, IPickupable
{
    [SerializeField]
    private UnityEvent finishedEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            finishedEvent.Invoke();
        }
    }
}
