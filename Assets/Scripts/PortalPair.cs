using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPair : MonoBehaviour
{
    private GameObject portal1;
    private GameObject portal2;

    private GameObject portalCamera;

    public GameObject portalPrefab;
    public GameObject cameraPrefab;

    public Material cameraMat;

    private int room1ID;
    private int room2ID;
    private CharacterController player;
    private Transform playerCamera;

    private static int currentPlayerRoomID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Static functions
    public static void SetCurrentPlayerRoomID(int input)
    {
        currentPlayerRoomID = input;
    }
    public static int GetCurrentPlayerRoomID(int input)
    {
        return currentPlayerRoomID;
    }



    // Setters / initializers
    public void SetRoom1ID(int input)
    {
        room1ID = input;
    }
    public void SetRoom2ID(int input)
    {
        room2ID = input;
    }
    public void SetPlayer(CharacterController input)
    {
        player = input;
    }
    public void SetPlayerCamera(Transform input)
    {
        playerCamera = input;
    }

    public void CreatePortals(Transform portal1Transform, Transform portal2Transform)
    {
        // Create the portals
        portal1 = Instantiate(portalPrefab);
        portal1.transform.position = portal1Transform.position;
        portal1.transform.rotation = portal1Transform.rotation;

        portal2 = Instantiate(portalPrefab);
        portal2.transform.position = portal2Transform.position;
        portal2.transform.rotation = portal2Transform.rotation;

        // Set the properties
        portal1.GetComponent<Portal>().SetRoomID(room1ID);
        portal1.GetComponent<Portal>().SetOtherRoomID(room2ID);
        portal1.GetComponent<Portal>().SetPlayer(player);
        portal1.GetComponent<Portal>().CreatePlanes();

        portal2.GetComponent<Portal>().SetRoomID(room2ID);
        portal2.GetComponent<Portal>().SetOtherRoomID(room1ID);
        portal2.GetComponent<Portal>().SetPlayer(player);
        portal2.GetComponent<Portal>().CreatePlanes();

        // Each portal's collider plane needs to know about the other's collider plane
        portal1.GetComponent<Portal>().SetColliderPlaneReceiver(portal2.GetComponent<Portal>().GetColliderPlaneTransform());
        portal2.GetComponent<Portal>().SetColliderPlaneReceiver(portal1.GetComponent<Portal>().GetColliderPlaneTransform());
    }

    public void CreateCamera()
    {
        portalCamera = Instantiate(cameraPrefab);
        portalCamera.GetComponent<PortalCamera>().SetPlayerCamera(playerCamera);
        portalCamera.GetComponent<PortalCamera>().SetPortal(portal2.transform);
        portalCamera.GetComponent<PortalCamera>().SetPlayerPortal(portal1.transform);

        if (portalCamera.GetComponent<Camera>().targetTexture != null)
        {
            portalCamera.GetComponent<Camera>().targetTexture.Release();
        }
        portalCamera.GetComponent<Camera>().targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat.mainTexture = portalCamera.GetComponent<Camera>().targetTexture;
    }
}
