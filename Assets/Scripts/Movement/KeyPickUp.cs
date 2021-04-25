using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerStatus>().keys++;

            this.gameObject.SetActive(false);

            Debug.Log("Player Picked up Key: " + gameObject.name);
        }
    }
}
