using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void Event();

public class WinBoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _winScreen;

    private static Event _onWin;

    public static Event OnWin { get => _onWin; set => _onWin = value; }

    private void Awake()
    {
        _onWin += () => _winScreen.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnWin?.Invoke();
    }
}
