using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private Transform playerCamera;
    private Transform portal;
    private Transform playerPortal;

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

    public void SetPlayerCamera(Transform input)
    {
        playerCamera = input;
    }
    public void SetPortal(Transform input)
    {
        portal = input;
    }
    public void SetPlayerPortal(Transform input)
    {
        playerPortal = input;
    }
}
