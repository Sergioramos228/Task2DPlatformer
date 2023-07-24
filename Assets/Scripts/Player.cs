using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private float _saveTime = 2;
    private float _currentSaveTime = 0;

    private void Awake()
    {
        TryGetComponent(out _animator);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_currentSaveTime <= 0 && collision.gameObject.TryGetComponent(out Enemy _))
        {
            _currentSaveTime = _saveTime;
            StartCoroutine(SaveTimeDuration());
            _animator.SetTrigger("Hit");
        }
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator SaveTimeDuration()
    {
        while (_currentSaveTime > 0)
        {
            _currentSaveTime -= Time.deltaTime;
            yield return null;
        }
    }
}
