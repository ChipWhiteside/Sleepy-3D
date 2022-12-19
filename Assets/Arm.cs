using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField]
    private bool aimingRight = true;

    void Update()
    {
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

        if (((angle > 90 && angle < 270) && aimingRight) || ((angle < 90 || angle > 270) && !aimingRight))
        {
            Flip();
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg + 180;
    }

    void Flip()
    {
        aimingRight = !aimingRight;
        Vector3 tScale = transform.localScale;
        tScale.y *= -1;
        transform.localScale = tScale;
    }
}
