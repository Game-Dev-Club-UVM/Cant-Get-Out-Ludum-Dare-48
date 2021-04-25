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
            keyBody = Instantiate(keyPrefab, playercam.GetChild(0).position, playercam.rotation) as Rigidbody;
            DisablePickUp(keyBody.gameObject);
            keyBody.AddForce(player.forward * 500);
            player.GetComponent<UIUpdater>().ThrowKey();

        }
    }

    IEnumerable DisablePickUp(GameObject key)
	{
        key.GetComponent<KeyPickUp>().SetActive(false);
        yield return new WaitForSeconds(2);
        key.GetComponent<KeyPickUp>().SetActive(true);
    }
}
