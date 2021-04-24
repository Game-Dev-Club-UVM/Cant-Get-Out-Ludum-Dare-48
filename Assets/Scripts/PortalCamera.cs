using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform playerPortal;

    private bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - playerPortal.position;
        transform.position = portal.position + (Quaternion.AngleAxis(180, Vector3.up) * playerOffsetFromPortal);

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, playerPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * (Quaternion.AngleAxis(180, Vector3.up) * playerCamera.forward);
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

    public void SetIsActive(bool input)
    {
        isActive = input;
    }
}
