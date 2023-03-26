using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow
{
    private Transform cameraTransform;
    private Transform targetTransform;

    public CameraFollow(Transform cameraTransform)
    {
        this.cameraTransform = cameraTransform;
    }

    public void SetTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    public void Update()
    {
        if (targetTransform != null)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetTransform.position, Time.deltaTime);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetTransform.rotation, Time.deltaTime);
        }
    }
}