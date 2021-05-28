using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinBoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _onWin?.Invoke();
    }
}
