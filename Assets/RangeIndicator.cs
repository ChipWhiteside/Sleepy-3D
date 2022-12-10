using Silence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

[RequireComponent(typeof(LineRenderer))]
public class RangeIndicator : MonoBehaviour
{
    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 10)]
    public float radius = 3f;
    [Range(0, 10)]
    public float width = 5f;
    LineRenderer line;

    void Update()
    {
        radius = PlayerController.instance.range;

        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * (radius / 10);
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * (radius / 10);

            line.SetPosition(i, new Vector3(x, y, 0));
            line.startWidth = width / 100;
            line.endWidth = width / 100;

            angle += (360f / segments);
        }
    }
}
