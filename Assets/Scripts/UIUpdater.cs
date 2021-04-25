using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    public int maxKeysInRoom = 0;
    public int keysLeftInRoom = 0;
    public int keysHeld = 0;
    public int depth = 0;
    public int areasExplored = 0;

    private TextMeshProUGUI keysLeftText;
    private TextMeshProUGUI keysHeldText;
    private TextMeshProUGUI depthText;
    private TextMeshProUGUI areasExploredText;

    private PlayerStatus stats;

    private void Start()
    {
        keysLeftText = GameObject.Find("KeysLeftText").GetComponent<TextMeshProUGUI>();
        keysHeldText = GameObject.Find("KeysHeldText").GetComponent<TextMeshProUGUI>();
        depthText = GameObject.Find("DepthText").GetComponent<TextMeshProUGUI>();
        areasExploredText = GameObject.Find("ExploredText").GetComponent<TextMeshProUGUI>();

        stats = this.GetComponent<PlayerStatus>();

        UpdateText();
    }

    private void Update()
    {
        //keysHeld = stats.keys;
        //UpdateText();
    }

    private void UpdateText()
    {
        keysLeftText.text = keysLeftInRoom + " / " + maxKeysInRoom;
        keysHeldText.text = "x " + keysHeld;
        depthText.text = "Depth: " + depth;
        areasExploredText.text = "Rooms Explored: " + areasExplored;
    } 

    public void UpdateToRoom(int maxKeysInRoom, int keysLeftInRoom, int depth, bool explored)
    {
        if (!explored)
        {
            areasExplored++;
        }
        this.depth = depth;
        this.maxKeysInRoom = maxKeysInRoom;
        this.keysLeftInRoom = keysLeftInRoom;

        UpdateText();
    }

    public void PickupKey()
    {
        keysLeftInRoom--;
        keysHeld++;

        UpdateText();
    }

    public void ThrowKey()
    {
        keysLeftInRoom++;
        keysHeld--;

        UpdateText();
    }

    public void UseKey()
    {
        keysHeld--;

        UpdateText();
    }
}
