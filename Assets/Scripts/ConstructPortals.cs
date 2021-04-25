using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructPortals : MonoBehaviour
{
    public GameObject portalPairPrefab;
    public CharacterController player;
    //public Transform playerCameraTransform;

    public Transform portal1transform;
    public Transform portal2transform;
    public Transform portal3transform;
    public Transform portal4transform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pair1 = Instantiate(portalPairPrefab);
        pair1.GetComponent<PortalPair>().SetPlayer(player);
        //pair1.GetComponent<PortalPair>().SetPlayerCamera(playerCameraTransform);
        pair1.GetComponent<PortalPair>().SetRoom1ID(1);
        pair1.GetComponent<PortalPair>().SetRoom2ID(2);
        pair1.GetComponent<PortalPair>().CreatePortals(portal1transform, portal2transform);
        //pair1.GetComponent<PortalPair>().CreateCamera();

        GameObject pair2 = Instantiate(portalPairPrefab);
        pair2.GetComponent<PortalPair>().SetPlayer(player);
        //pair2.GetComponent<PortalPair>().SetPlayerCamera(playerCameraTransform);
        pair2.GetComponent<PortalPair>().SetRoom1ID(3);
        pair2.GetComponent<PortalPair>().SetRoom2ID(4);
        pair2.GetComponent<PortalPair>().CreatePortals(portal3transform, portal4transform);
        //pair2.GetComponent<PortalPair>().CreateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
