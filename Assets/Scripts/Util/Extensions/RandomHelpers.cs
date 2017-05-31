using UnityEngine;

public static class RandomHelpers
{
    public static Vector3 RandomPointInBox(this BoundingBox box) 
    {
        return box.GetPointInBoundingBox(Random.value, Random.value, Random.value);
    }
}