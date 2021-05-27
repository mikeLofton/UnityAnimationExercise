using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpScale;
    private Vector3 _velocity;
    [SerializeField]
    private bool _isGrounded;
    private Collider _collider;
    private float _distanceToGround;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _distanceToGround = _collider.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _distanceToGround + 0.1f);
        _velocity.x = Input.GetAxis("Horizontal");   
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _jumpScale, ForceMode.Impulse);
            _isGrounded = false;
        }

        _rigidbody.isKinematic = _isGrounded;
    }
}
