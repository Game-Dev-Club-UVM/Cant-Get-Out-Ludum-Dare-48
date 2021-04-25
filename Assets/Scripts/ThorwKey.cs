using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorwKey : MonoBehaviour
{
   
    public Rigidbody keyPrefab;
    public Transform player;
    public Transform playercam;
    public int keys = 0;


    void Update()
    {
        keys = player.GetComponent<UIUpdater>().keysHeld;
        if (Input.GetButtonDown("Fire1") && keys > 0 )
        {
            
            Rigidbody keyBody;
            keyBody = Instantiate(keyPrefab, playercam.position, playercam.rotation) as Rigidbody;
            keyBody.gameObject.SetActive(true);
            keyBody.AddForce(player.forward * 500);
            player.GetComponent<UIUpdater>().ThrowKey();

        }
    }
}
