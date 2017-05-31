using System;
using UnityEngine;

[Serializable]
public struct BoundingBox
{
    public Vector3 Center;
    public Vector3 Extent;
    public Quaternion Rotation;

    public BoundingBox(Vector3 center, Vector3 extent)
    {
        Center = center;
        Extent = extent;
        Rotation = Quaternion.identity;
    }
    public BoundingBox(Vector3 center, Vector3 extent, Quaternion rotation)
    {
        Center = center;
        Extent = extent;
        Rotation = rotation;
    }

    public Vector3 GetPointInBoundingBox(Vector3 ratioVector)
    {
        return GetPointInBoundingBox(ratioVector.x, ratioVector.y, ratioVector.z);
    }
    public Vector3 GetPointInBoundingBox(float xRatio, float yRatio, float zRatio)
    {
        return Center + Rotation * Vector3.Scale(Extent, new Vector3(xRatio - 0.5f, yRatio - 0.5f, zRatio - 0.5f));
    }
}