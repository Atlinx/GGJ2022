using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera camera;
    public LayerMask dimensionOneMask;
    public LayerMask dimensionTwoMask;

    public Transform Target;
    
    public void SwapRender(int id)
    {
        if (id == 0)
        {
            camera.cullingMask = dimensionOneMask;
        }
        else if (id == 1)
        {
            camera.cullingMask = dimensionTwoMask;
        }
    }

    private void Update()
    {
        Vector3 position = Target.transform.position;
        camera.transform.position = new Vector3(position.x, position.y, camera.transform.position.z);
    }
}
