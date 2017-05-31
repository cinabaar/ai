using UnityEngine;

public class BoundingBoxComponent : MonoBehaviour
{
    public BoundingBox Box;

    private Transform _transform;

	void Start ()
    {
        _transform = gameObject.transform;
	}

    void OnDrawGizmos()
    {
        Box.Rotation = gameObject.transform.rotation;
        Box.Center = gameObject.transform.position;

        for (int i = 0; i <= 1; i++)
            for (int j = 0; j <= 1; j++)
                for (int k = 0; k <= 1; k++)
                    for (int l = 0; l <= 1; l++)
                        for (int m = 0; m <= 1; m++)
                            for (int n = 0; n <= 1; n++)
                            {
                                var pos1 = new Vector3(i, j, k);
                                var pos2 = new Vector3(l, m, n);
                                if ((pos1 - pos2).magnitude > 1) continue;
                                Gizmos.color = Color.magenta;
                                Gizmos.DrawLine(Box.GetPointInBoundingBox(pos1), Box.GetPointInBoundingBox(pos2));
                            }
    }
}
