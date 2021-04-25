using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public int maxKeysInRoom = 2;
    public int keysLeftInRoom = 2;
    public int keysHeld = 0;
    public int depth = 1;
    public int areasExplored = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateToNewRoom(int maxKeysInRoom, int keysLeftInRoom, int depth, bool explored)
    {
        if (!explored)
        {
            areasExplored++;
        }
        this.depth = depth;
        this.maxKeysInRoom = maxKeysInRoom;
        this.keysLeftInRoom = keysLeftInRoom;
    }
}
