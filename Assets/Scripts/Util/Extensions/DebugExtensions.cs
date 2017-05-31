using UnityEngine;

public static class DebugExtensions
{
    public static void DebugDrawCircle(Vector3 center, float radius, float duration)
    {
        DebugDrawCircle(center, radius, duration, 12, Color.red, Vector3.up);
    }
    public static void DebugDrawCircle(Vector3 center, float radius, float duration, int segments, Color color, Vector3 up)
    {
        Vector3 starting;
        if(up.y != 0)
        {
            starting = new Vector3(1, (up.x + up.z) / -up.y, 1);
        }
        else if (up.z != 0)
        {
            starting = new Vector3(1, 1, (up.x + up.y) / -up.z);
        }
        else if(up.x != 0)
        {
            starting = new Vector3((up.y + up.z) / -up.x, 1, 1);
        }
        else
        {
            return;
        }
        starting = starting.normalized * radius;

        var increment = 360f / segments;

        for(int i = 0; i < segments; i++)
        {
            var p1 = Quaternion.AngleAxis(i * increment, up) * starting + center;
            var p2 = Quaternion.AngleAxis((i + 1) * increment, up) * starting + center;
            Debug.DrawLine(p1, p2, color, duration);
        }
    }
}
