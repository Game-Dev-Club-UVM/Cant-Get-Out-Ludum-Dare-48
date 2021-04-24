using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            Vector3 incomingOffset = player.transform.position - transform.position;
            float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
            float incomingAngle = Vector3.Angle(incomingOffset, transform.forward);
            Debug.Log("inc angle " + incomingAngle);
            float outgoingAngle = -incomingAngle;
            Vector3 outgoingOffset = Quaternion.Euler(0f, outgoingAngle, 0f) * incomingOffset;
            player.transform.Rotate(Vector3.up, rotationDiff + 2*outgoingAngle);
            player.enabled = false;
            player.transform.position = receiver.position + outgoingOffset;
            player.enabled = true;
            Debug.Log("incoming offset " + incomingOffset.ToString());
            Debug.Log("outgoing offset " + outgoingOffset.ToString());
            playerIsOverlapping = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    public static float Angle2D(Vector3 v1, Vector3 v2)
    {
        return Mathf.Atan2(v2.z - v1.z, v2.x - v1.x);
    }
}
