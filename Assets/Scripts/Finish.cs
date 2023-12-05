using UnityEngine;

public class Finish : MonoBehaviour
{
    private ParticleSystem _finishEffect;

    private void Awake()
    {
         TryGetComponent(out _finishEffect);
    }
    public void EndGame()
    {
        _finishEffect.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
