using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 SetX(this Vector3 vec, float x)
    {
        return new Vector3(x, vec.y, vec.z);
    }
    public static Vector3 SetY(this Vector3 vec, float y)
    {
        return new Vector3(vec.x, y, vec.z);
    }
    public static Vector3 SetZ(this Vector3 vec, float z)
    {
        return new Vector3(vec.x, vec.y, z);
    }
    public static Vector3 ToVec3(this Vector2 vec, float y)
    {
        return new Vector3(vec.x, y, vec.y);
    }
    public static Vector2 ToVec2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.z);
    }
}
