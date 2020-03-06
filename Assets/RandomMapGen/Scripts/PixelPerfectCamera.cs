using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add this to the camera
public class PixelPerfectCamera : MonoBehaviour
{
    public static float pixelToUnits = 1f;
    public static float scale = 1f;

    // native resolution of the original gameboy
    public Vector2 nativeResolution = new Vector2(160, 144);


    private void Awake()
    {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            var dir = Screen.height;
            var res = nativeResolution.y;

            scale = dir / res;
            pixelToUnits *= scale;

            camera.orthographicSize = (dir / 2.0f) / pixelToUnits;
        }
    }
}
