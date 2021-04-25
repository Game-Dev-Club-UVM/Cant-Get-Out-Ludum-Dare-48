using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            
            this.gameObject.SetActive(false);
            other.GetComponent<UIUpdater>().PickupKey();

            Debug.Log("Player Picked up Key: " + gameObject.name);
        }
    }
}
