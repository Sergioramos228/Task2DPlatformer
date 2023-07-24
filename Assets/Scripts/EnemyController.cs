using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _movingDistance;
    [SerializeField] private float _speed;
    private Vector3 _targetPosition;

    private void Awake()
    {
        if (_movingDistance == 0)
            _movingDistance = 1;
        if (_speed == 0)
            _speed = 1;
        _targetPosition = new Vector2(transform.position.x - _movingDistance, transform.position.y);
        StartCoroutine(MovingEnemy());
    }

    private IEnumerator MovingEnemy()
    {
        yield return null;

        while (transform.position.x != _targetPosition.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            if (transform.position.x == _targetPosition.x)
            {
                if (_targetPosition.x < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    _targetPosition.x += _movingDistance;
                }
                else if (_targetPosition.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    _targetPosition.x -= _movingDistance;
                }
            }
            yield return null;
        }
    }
}
