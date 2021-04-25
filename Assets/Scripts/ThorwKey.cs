using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorwKey : MonoBehaviour
{
   
    public Rigidbody keyPrefab;
    public Transform player;
    public Transform playercam;
    public int keys = 1;


    void Update()
    {
        keys = player.GetComponent<PlayerStatus>().keys;
        if (Input.GetButtonDown("Fire1") && keys > 0 )
        {
            keys = player.GetComponent<PlayerStatus>().keys--;
            Rigidbody keyBody;
            keyBody = Instantiate(keyPrefab, playercam.position, playercam.rotation) as Rigidbody;
            keyBody.AddForce(player.forward * 500);
           
        }
    }
}
