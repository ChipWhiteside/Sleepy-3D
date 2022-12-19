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
    //[Range(0, 10)]
    //public float radius = 3f;
    [Range(0, 10)]
    public float width = 5f;

    public Transform rangeSprite;
    
    LineRenderer line;
    PlayerController playerController;

    private void Start()
    {
        playerController = PlayerController.instance;
        rangeSprite.transform.localScale = Vector3.one * (playerController.range / 10 + 1);
    }

    void Update()
    {
        SpriteRenderer sr = rangeSprite.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, playerController.rangeIndicatorAlpha);
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();

        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * (playerController.range / 10);
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * (playerController.range / 10);

            line.SetPosition(i, new Vector3(x, y, 0));
            line.startWidth = width / 100;
            line.endWidth = width / 100;

            angle += (360f / segments);
        }
    }
}
