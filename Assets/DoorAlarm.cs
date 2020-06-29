using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorAlarm : MonoBehaviour
{
    public UnityEvent doorEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Check");
            doorEvent.Invoke();

        }
    }
}
