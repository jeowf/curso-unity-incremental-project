using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtensions
{
    public static Vector2 BoundsMin(this Camera camera)
    {
        Vector2 v = new Vector2(camera.transform.position.x, camera.transform.position.y);
        return v - camera.Extents();
    }

    public static Vector2 BoundsMax(this Camera camera)
    {
        Vector2 v = new Vector2(camera.transform.position.x, camera.transform.position.y);
        return v + camera.Extents();
    }

    public static Vector2 Extents(this Camera camera)
    {
        if (camera.orthographic)
            return new Vector2(camera.orthographicSize * Screen.width / Screen.height, camera.orthographicSize);
        else
        {
            Debug.LogError("Camera is not orthographic!", camera);
            return new Vector2();
        }
    }

}
