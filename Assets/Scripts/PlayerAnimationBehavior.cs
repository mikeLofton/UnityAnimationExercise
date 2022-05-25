using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehaviour _playerMovement;
    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        WinBoxBehaviour.OnWin += () => _animator.SetTrigger("Win");
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _playerMovement.Velocity.magnitude);

        _animator.SetBool("IsGrounded", _playerMovement.IsGrounded);
    }
}
