using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    // An amount to move the player by to make sure the player is not
    // colliding with the other portal immediately after going through
    public static float teleportationScaleFactor = 1.8f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;

            Vector3 portalToPlayer = player.transform.position - transform.position;
            float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            //rotationDiff += 180;
            player.transform.Rotate(Vector3.up, rotationDiff + 180f);
            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            player.enabled = false;
            player.transform.position = receiver.position + teleportationScaleFactor * positionOffset;
            Debug.Log("teleported to " + (receiver.position + positionOffset));
            player.enabled = true;

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
}
