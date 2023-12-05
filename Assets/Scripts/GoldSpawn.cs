using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Gold))]

public class GoldSpawn : MonoBehaviour
{
    [SerializeField] private Gold _template;
    [SerializeField] private Path _path;

    private void Start()
    {
        StartCoroutine(CreateGold(0.01f));
    }

    private IEnumerator CreateGold(float spawnTime)
    {
        yield return null;

        while (_path.TryGetNextPoint(out Point point))
        {
            Instantiate(_template, point.transform.position, Quaternion.identity);
        }

        yield return spawnTime;
    }
}
