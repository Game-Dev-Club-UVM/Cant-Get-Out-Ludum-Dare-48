using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    bool active = true;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && active)
        {
            
            this.gameObject.SetActive(false);
            other.GetComponent<UIUpdater>().PickupKey();

            Debug.Log("Player Picked up Key: " + gameObject.name);
        }
    }

    public void SetActive(bool b)
	{
        active = b;
    }
}
