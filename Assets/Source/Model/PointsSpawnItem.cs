using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PointsSpawnItem
{
    private readonly List<Vector3> _pointsSpawn;

    public PointsSpawnItem(List<Vector3> pointsSpawn)
    {
        _pointsSpawn = pointsSpawn;
    }

    public Vector3 GetRandomPosition()
    {
        if (_pointsSpawn.Count == 0)
            throw new InvalidOperationException();

        int index = Random.Range(0, _pointsSpawn.Count);
        Vector3 point = _pointsSpawn[index];
        _pointsSpawn.Remove(point);

        return point;
    }
}