using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    private float _moveInput;

    void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate() 
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        if (_moveInput != 0)
        {
            int collisionCount = _rigidbody.Cast(new(_moveInput, 0), _filter, _results, 0.1f);

            if (collisionCount != 0)
                _moveInput = 0;
        }

        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);

        if (_moveInput == 0)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }

    void Update() 
    {
        int collisionCount = _rigidbody.Cast(Vector2.down, _filter, _results, 0.1f);

        if (_moveInput < 0 && collisionCount > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_moveInput > 0 && collisionCount > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxisRaw("Jump") == 1 && collisionCount > 0)
        {
            if (_moveInput == 0)
            {
                _animator.SetTrigger("takeOff");
            }
            else if (_moveInput == 1)
            {
                _animator.SetTrigger("takeOffWall");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (_moveInput == -1)
            {
                _animator.SetTrigger("takeOffWall");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            _rigidbody.velocity = Vector2.up * _jumpForce;
        }

        if (collisionCount == 0)
        {
            _animator.SetBool("isJumping", true);

        }

        if (collisionCount > 0)
        {
            _animator.SetBool("isJumping", false);
        }
    }
}