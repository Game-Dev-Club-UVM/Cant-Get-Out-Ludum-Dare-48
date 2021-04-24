using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPlane : MonoBehaviour
{
    private CharacterController player;
    private Transform receiver;

    private int roomID;
    private int otherRoomID;

    // An amount to move the player by to make sure the player is not
    // colliding with the other portal immediately after going through
    public static float teleportationScaleFactor = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Translate and rotate the player to go through the portal
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            player.transform.Rotate(Vector3.up, rotationDiff + 180f);
            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            player.enabled = false;
            player.transform.position = receiver.position + teleportationScaleFactor * positionOffset;
            player.enabled = true;

            // Let everyone know where the player is
            PortalPair.SetCurrentPlayerRoomID(otherRoomID);
        }
    }

    // Setters
    public void SetRoomID(int id)
    {
        roomID = id;
    }
    public void SetOtherRoomID(int id)
    {
        otherRoomID = id;
    }
    public void SetPlayer(CharacterController input)
    {
        player = input;
    }
    public void SetReceiver(Transform input)
    {
        receiver = input;
    }
}
