using System.Xml;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class Collision : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _filter;

    private Rigidbody2D _rigidbody2D;
    private float _moveInput;
    private Player _player;
    
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    
    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new(_moveInput, 0);
        _rigidbody2D.Cast(direction, _results, 0.1f);

        if (_results[0].collider.gameObject.TryGetComponent(out Enemy _))
        {
            
        }
    }
}
