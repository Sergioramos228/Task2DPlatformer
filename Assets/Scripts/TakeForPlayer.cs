using UnityEngine;

public class TakeForPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _takeFinishSound;
    [SerializeField] private AudioSource _takeGoldSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Gold gold))
        {
            _takeGoldSound.Play();
            gold.Destroy();
        }

        if (collision.TryGetComponent(out Finish finish))
        {
            _takeFinishSound.Play();
            finish.EndGame();
        }
    }
}
