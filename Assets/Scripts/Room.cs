using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorFramePrefab;
    public GameObject halfWallPrefab;
    public GameObject floorPrefab;

    private GameObject northDoorFrame;
    private GameObject eastDoorFrame;
    private GameObject southDoorFrame;
    private GameObject westDoorFrame;

    private GameObject floor;

    private bool northDoorLinked = false;
    private bool eastDoorLinked = false;
    private bool southDoorLinked = false;
    private bool westDoorLinked = false;

    private int level;

    public Material mat0;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;
    public Material mat6;

    // The square of each room
    public static float roomSize = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Setters and initializers
    public void SetLevel(int input)
    {
        level = input;
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void CreateDoorFrames()
    {
        northDoorFrame = Instantiate(doorFramePrefab);
        northDoorFrame.transform.SetParent(transform);
        northDoorFrame.transform.localPosition = new Vector3(0, 0, roomSize / 2f);
        northDoorFrame.transform.Rotate(Vector3.up, 180f);
        northDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.N);

        eastDoorFrame = Instantiate(doorFramePrefab);
        eastDoorFrame.transform.SetParent(transform);
        eastDoorFrame.transform.localPosition = new Vector3(roomSize / 2f, 0, 0);
        eastDoorFrame.transform.Rotate(Vector3.up, 270f);
        eastDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.E);

        southDoorFrame = Instantiate(doorFramePrefab);
        southDoorFrame.transform.SetParent(transform);
        southDoorFrame.transform.localPosition = new Vector3(0, 0, -roomSize / 2f);
        southDoorFrame.transform.Rotate(Vector3.up, 0f);
        southDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.S);

        westDoorFrame = Instantiate(doorFramePrefab);
        westDoorFrame.transform.SetParent(transform);
        westDoorFrame.transform.localPosition = new Vector3(-roomSize / 2f, 0, 0);
        westDoorFrame.transform.Rotate(Vector3.up, 90f);
        westDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.W);
    }
    public void CreateFloor()
    {
        floor = Instantiate(floorPrefab);
        floor.transform.localScale = new Vector3(roomSize/10f, 1f, roomSize/10f);
        floor.transform.position = transform.position;
        if(level == 0)
        {
            floor.GetComponent<Renderer>().material = mat0;
        }
        else if(level == 1)
        {
            floor.GetComponent<Renderer>().material = mat1;
        }
        else if (level == 2)
        {
            floor.GetComponent<Renderer>().material = mat2;
        }
        else if (level == 3)
        {
            floor.GetComponent<Renderer>().material = mat3;
        }
        else if (level == 4)
        {
            floor.GetComponent<Renderer>().material = mat4;
        }
        else if (level == 5)
        {
            floor.GetComponent<Renderer>().material = mat5;
        }
        else
        {
            floor.GetComponent<Renderer>().material = mat6;
        }
    }



    // Getters
    public DoorFrame NorthDoorFrame()
    {
        return northDoorFrame.GetComponent<DoorFrame>();
    }
    public DoorFrame EastDoorFrame()
    {
        return eastDoorFrame.GetComponent<DoorFrame>();
    }
    public DoorFrame SouthDoorFrame()
    {
        return southDoorFrame.GetComponent<DoorFrame>();
    }
    public DoorFrame WestDoorFrame()
    {
        return westDoorFrame.GetComponent<DoorFrame>();
    }
    public bool NorthDoorLinked()
    {
        return northDoorLinked;
    }
    public bool EastDoorLinked()
    {
        return eastDoorLinked;
    }
    public bool SouthDoorLinked()
    {
        return southDoorLinked;
    }
    public bool WestDoorLinked()
    {
        return westDoorLinked;
    }
    public bool HasUnlinkedDoor()
    {
        return !northDoorLinked || !eastDoorLinked || !southDoorLinked || !westDoorLinked;
    }
    public bool HasLinkedDoor()
    {
        return northDoorLinked || eastDoorLinked || southDoorLinked || westDoorLinked;
    }
    public int NumUnlinkedDoors()
    {
        int count = 0;
        if(!northDoorLinked)
        {
            count++;
        }
        if(!eastDoorLinked)
        {
            count++;
        }
        if (!westDoorLinked)
        {
            count++;
        }
        if (!southDoorLinked)
        {
            count++;
        }
        return count;
    }

    public DoorFrame GetRandomUnlinkedDoor()
    {
        if(!HasUnlinkedDoor())
        {
            Debug.Log("Error! Trying to get an unlinked door from a room that does not have one.");
        }
        while(true)
        {
            int randomIndex = Random.Range(0, 4);
            if(randomIndex == 0 && !northDoorLinked)
            {
                northDoorLinked = true;
                return northDoorFrame.GetComponent<DoorFrame>();
            }
            else if (randomIndex == 1 && !eastDoorLinked)
            {
                eastDoorLinked = true;
                return eastDoorFrame.GetComponent<DoorFrame>();
            }
            else if (randomIndex == 2 && !southDoorLinked)
            {
                southDoorLinked = true;
                return southDoorFrame.GetComponent<DoorFrame>();
            }
            else if (randomIndex == 3 && !westDoorLinked)
            {
                westDoorLinked = true;
                return westDoorFrame.GetComponent<DoorFrame>();
            }
        }
    }

    // Set door linked booleans when a portal is made
    public void LinkNorthDoor()
    {
        northDoorLinked = true;
    }
    public void LinkEastDoor()
    {
        eastDoorLinked = true;
    }
    public void LinkSouthDoor()
    {
        southDoorLinked = true;
    }
    public void LinkWestDoor()
    {
        westDoorLinked = true;
    }
}
