using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Queue<Point> _points;

    private void Awake()
    {
        _points = new Queue<Point>();

        foreach (Point child in gameObject.GetComponentsInChildren<Point>())
            _points.Enqueue(child);
    }

    public bool TryGetNextPoint(out Point point)
    {
        return _points.TryDequeue(out point);
    }
}
