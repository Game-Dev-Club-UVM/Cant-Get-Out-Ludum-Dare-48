using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject colliderPlanePrefab;
    public GameObject renderPlanePrefab;
    public GameObject doorPrefab;

    private int roomID;
    private int otherRoomID;

    private CharacterController player;

    private GameObject colliderPlane;
    private GameObject renderPlane;
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void CreateDoor()
    {
        door = Instantiate(doorPrefab);
        door.transform.position = transform.position + 0.5f*transform.up;
        door.transform.rotation = transform.rotation;
    }
    public void CreatePlanes()
    {
        renderPlane = Instantiate(renderPlanePrefab);
        renderPlane.transform.position = transform.position;
        // Plane faces up by default, make it vertical
        renderPlane.transform.rotation = transform.rotation;

        colliderPlane = Instantiate(colliderPlanePrefab);
        colliderPlane.transform.position = transform.position;
        colliderPlane.transform.rotation = transform.rotation;
        colliderPlane.GetComponent<ColliderPlane>().SetRoomID(roomID);
        colliderPlane.GetComponent<ColliderPlane>().SetOtherRoomID(otherRoomID);
        colliderPlane.GetComponent<ColliderPlane>().SetPlayer(player);
    }
    public void SetColliderPlaneReceiver(Transform otherColliderPlane)
    {
        colliderPlane.GetComponent<ColliderPlane>().SetReceiver(otherColliderPlane);
    }

    public Transform GetColliderPlaneTransform()
    {
        return colliderPlane.transform;
    }
}
