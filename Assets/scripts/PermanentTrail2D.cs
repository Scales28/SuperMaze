using System.Collections.Generic;
using UnityEngine;

public class PermanentTrail2D : MonoBehaviour
{
    public float minDistance = 0.1f;

    private LineRenderer line;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;

        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], pos) > minDistance)
        {
            points.Add(pos);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, pos);
        }
    }
}
