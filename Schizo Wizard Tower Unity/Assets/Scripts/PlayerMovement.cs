using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _rb.linearVelocity = _movement * _moveSpeed;
    }

    public void move(InputAction.CallbackContext ctx)
    { 
        _movement = ctx.ReadValue<Vector2>();

        _animator.SetFloat("x", _movement.x);
        _animator.SetFloat("y", _movement.y);
    }
}
