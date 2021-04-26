using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject portalPairPrefab;
    public CharacterController player;

    private List<List<GameObject>> levels = new List<List<GameObject>>();

    public int numDoorsPerLevel = 4;
    public int numRoomsPerLevel = 2;
    public int numLevels = 6;
    // Each room has to fit into a square of this size
    public int propertySize = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.CreateRooms();
        this.CreatePortals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRooms()
    {
        // Make the starting room
        levels.Add(new List<GameObject>());
        GameObject startingRoom = Instantiate(roomPrefab);
        startingRoom.transform.position = GetRoomPosition(0, 1);
        startingRoom.GetComponent<Room>().SetLevel(0);
        startingRoom.GetComponent<Room>().CreateDoorFrames();
        startingRoom.GetComponent<Room>().CreateFloor();
        startingRoom.GetComponent<Room>().CreateWalls();
        levels[0].Add(startingRoom);

        // Make rooms for each level
        for(int level = 1; level < numLevels + 1; level++)
        {
            List<GameObject> currentLevel = new List<GameObject>();
            for(int index = 1; index < numRoomsPerLevel + 1; index++)
            {
                GameObject room = Instantiate(roomPrefab);
                room.transform.position = GetRoomPosition(level, index);
                room.GetComponent<Room>().SetLevel(level);
                room.GetComponent<Room>().CreateDoorFrames();
                room.GetComponent<Room>().CreateFloor();
                room.GetComponent<Room>().CreateWalls();
                currentLevel.Add(room);
            }
            levels.Add(currentLevel);
        }
    }
    public void CreatePortals()
    {
        // Link the four doors of the starting room to a random door in a 
        // random room in Level 1.
        for(int i = 0; i < 4; i++)
        {
            GameObject pair = Instantiate(portalPairPrefab);
            int roomID1 = GetRoomID(0, 1);
            int roomID2 = -1;
            Transform portal1transform = levels[0][0].GetComponent<Room>().GetRandomUnlinkedDoor().GetPortalTransform();
            Transform portal2transform = transform;

            // Search for a random room with a random unlinked door
            bool secondRoomFound = false;
            while(!secondRoomFound)
            {
                Room r;
                // First, look for an isolated room
                if(RoomGenerator.LevelHasIsolatedRoom(levels[1]))
                {
                    r = RoomGenerator.GetRandomIsolatedRoom(levels[1]);
                }
                else
                {
                    // If none, pick a random room
                    int randomIndex = Random.Range(0, numRoomsPerLevel);
                    r = levels[1][randomIndex].GetComponent<Room>();
                }

                if (r.HasUnlinkedDoor())
                {
                    secondRoomFound = true;
                    DoorFrame d = r.GetRandomUnlinkedDoor();
                    portal2transform = d.GetPortalTransform();
                }
            }
            pair.GetComponent<PortalPair>().SetPlayer(player);
            pair.GetComponent<PortalPair>().SetRoom1ID(roomID1);
            pair.GetComponent<PortalPair>().SetRoom2ID(roomID2);
            pair.GetComponent<PortalPair>().CreatePortals(portal1transform, portal2transform);
        }

        // Now iterate through the levels and link them
        for(int level = 1; level < numLevels; level++)
        {
            for(int room = 0; room < levels[level].Count; room++)
            {
                int doorsToLink = levels[level][room].GetComponent<Room>().NumUnlinkedDoors();
                for (int i = 0; i < doorsToLink; i++)
                {
                    GameObject pair = Instantiate(portalPairPrefab);
                    int roomID1 = GetRoomID(level, room);
                    int roomID2 = -1;
                    Transform portal1transform = levels[level][room].GetComponent<Room>().GetRandomUnlinkedDoor().GetPortalTransform();
                    Transform portal2transform = transform;

                    // Search for a random room with a random unlinked door
                    bool secondRoomFound = false;
                    while (!secondRoomFound)
                    {
                        Room r;
                        // First, look for an isolated room
                        if (RoomGenerator.LevelHasIsolatedRoom(levels[level + 1]))
                        {
                            r = RoomGenerator.GetRandomIsolatedRoom(levels[level + 1]);
                        }
                        else
                        {
                            // If none, pick a random room
                            int randomIndex = Random.Range(0, numRoomsPerLevel);
                            r = levels[level + 1][randomIndex].GetComponent<Room>();
                        }

                        if (r.HasUnlinkedDoor())
                        {
                            secondRoomFound = true;
                            DoorFrame d = r.GetRandomUnlinkedDoor();
                            portal2transform = d.GetPortalTransform();
                        }
                    }
                    pair.GetComponent<PortalPair>().SetPlayer(player);
                    pair.GetComponent<PortalPair>().SetRoom1ID(roomID1);
                    pair.GetComponent<PortalPair>().SetRoom2ID(roomID2);
                    pair.GetComponent<PortalPair>().CreatePortals(portal1transform, portal2transform);
                }
            }
        }
    }

    private Vector3 GetRoomPosition(int level, int index)
    {
        float z = level*propertySize + propertySize / 2f;
        float x = index * propertySize - propertySize / 2f;
        return new Vector3(x, 0, z);
    }
    private int GetRoomID(int level, int index)
    {
        if(level == 0)
        {
            return 0;
        }
        return level * numRoomsPerLevel + index;
    }
    private void LinkRandomDoors(int room1ID, int room2ID)
    {

    }

    // Check if a level has a room that has no portals linked to it yet
    public static bool LevelHasIsolatedRoom(List<GameObject> level)
    {
        for (int i = 0; i < level.Count; i++)
        {
            if (!level[i].GetComponent<Room>().HasLinkedDoor())
            {
                return true;
            }
        }
        return false;
    }
    public static Room GetRandomIsolatedRoom(List<GameObject> level)
    {
        while (true)
        {
            int r = Random.Range(0, level.Count);
            if (!level[r].GetComponent<Room>().HasLinkedDoor())
            {
                return level[r].GetComponent<Room>();
            }
        }
    }
}
