using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPlane : MonoBehaviour
{
    private CharacterController player;
    private Transform receiver;

    public static float playerDiameter = 0.8f;
    // Go a little further past the portal, so you don't go back into it immediately
    // Or be inside the door
    public static float offset = 0.1f;

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
            float rotationDiff = -Vector3.SignedAngle(transform.up, receiver.up, Vector3.up);
            player.transform.Rotate(Vector3.up, rotationDiff);

            float oldY = player.transform.position.y;
            player.enabled = false;
            player.transform.position = receiver.position + (playerDiameter + offset) * receiver.up;
            player.transform.position += Vector3.down * oldY;
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
