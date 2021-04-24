using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructPortals : MonoBehaviour
{
    public GameObject portalPairPrefab;
    public CharacterController player;
    public Transform playerCameraTransform;

    public Transform portal1transform;
    public Transform portal2transform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pair = Instantiate(portalPairPrefab);
        pair.GetComponent<PortalPair>().SetPlayer(player);
        pair.GetComponent<PortalPair>().SetPlayerCamera(playerCameraTransform);
        pair.GetComponent<PortalPair>().SetRoom1ID(1);
        pair.GetComponent<PortalPair>().SetRoom2ID(2);
        pair.GetComponent<PortalPair>().CreatePortals(portal1transform, portal2transform);
        pair.GetComponent<PortalPair>().CreateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
