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
    public Transform portal5transform;
    public Transform portal6transform;
    public Transform portal7transform;
    public Transform portal8transform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pair1 = Instantiate(portalPairPrefab);
        pair1.GetComponent<PortalPair>().SetPlayer(player);
        pair1.GetComponent<PortalPair>().SetRoom1ID(1);
        pair1.GetComponent<PortalPair>().SetRoom2ID(2);
        pair1.GetComponent<PortalPair>().CreatePortals(portal1transform, portal2transform);

        GameObject pair2 = Instantiate(portalPairPrefab);
        pair2.GetComponent<PortalPair>().SetPlayer(player);
        pair2.GetComponent<PortalPair>().SetRoom1ID(3);
        pair2.GetComponent<PortalPair>().SetRoom2ID(4);
        pair2.GetComponent<PortalPair>().CreatePortals(portal3transform, portal4transform);

        GameObject pair3 = Instantiate(portalPairPrefab);
        pair3.GetComponent<PortalPair>().SetPlayer(player);
        pair3.GetComponent<PortalPair>().SetRoom1ID(2);
        pair3.GetComponent<PortalPair>().SetRoom2ID(4);
        pair3.GetComponent<PortalPair>().CreatePortals(portal5transform, portal6transform);

        GameObject pair4 = Instantiate(portalPairPrefab);
        pair4.GetComponent<PortalPair>().SetPlayer(player);
        pair4.GetComponent<PortalPair>().SetRoom1ID(3);
        pair4.GetComponent<PortalPair>().SetRoom2ID(3);
        pair4.GetComponent<PortalPair>().CreatePortals(portal7transform, portal8transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
