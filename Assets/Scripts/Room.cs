using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorFramePrefab;
    public GameObject wallPrefab;
    public GameObject floorPrefab;

    private GameObject northDoorFrame;
    private GameObject eastDoorFrame;
    private GameObject southDoorFrame;
    private GameObject westDoorFrame;

    private GameObject floor;
    private GameObject ceiling;
    private List<GameObject> walls = new List<GameObject>();

    private bool northDoorLinked = false;
    private bool eastDoorLinked = false;
    private bool southDoorLinked = false;
    private bool westDoorLinked = false;

    private float northDoorLoc;
    private float eastDoorLoc;
    private float southDoorLoc;
    private float westDoorLoc;

    private int level;
    private Material floorMat;
    private Material wallMat;
    private int lightParameter;

    public Material floorMat0;
    public Material floorMat1;
    public Material floorMat2;
    public Material floorMat3;
    public Material floorMat4;
    public Material floorMat5;
    public Material floorMat6;

    public Material wallMat0;
    public Material wallMat1;
    public Material wallMat2;
    public Material wallMat3;
    public Material wallMat4;
    public Material wallMat5;
    public Material wallMat6;

    private GameObject wallNL;
    private GameObject wallNR;
    private GameObject wallEL;
    private GameObject wallER;
    private GameObject wallSL;
    private GameObject wallSR;
    private GameObject wallWL;
    private GameObject wallWR;

    private GameObject doorTopN;
    private GameObject doorTopE;
    private GameObject doorTopS;
    private GameObject doorTopW;

    private GameObject light;

    // The square of each room
    public static float roomSize = 30f;
    public static float wallLength = roomSize - 1f;

    public static float roomHeight = 5f;

    // The width of each door
    public static float doorWidth = 2f;

    // Don't put doors too close to a corner
    public static float cornerBuffer = 2f;

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
        if (level == 0)
        {
            floorMat = floorMat0;
            wallMat = wallMat0;
            lightParameter = 10;
        }
        else if (level == 1)
        {
            floorMat = floorMat1;
            wallMat = wallMat1;
            lightParameter = 7;
        }
        else if (level == 2)
        {
            floorMat = floorMat2;
            wallMat = wallMat2;
            lightParameter = 4;
        }
        else if (level == 3)
        {
            floorMat = floorMat3;
            wallMat = wallMat3;
            lightParameter = 2;
        }
        else if (level == 4)
        {
            floorMat = floorMat4;
            wallMat = wallMat4;
            lightParameter = 1;
        }
        else if (level == 5)
        {
            floorMat = floorMat5;
            wallMat = wallMat5;
            lightParameter = 0;
        }
        else
        {
            floorMat = floorMat6;
            wallMat = wallMat6;
            lightParameter = 10;
        }
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void CreateLight()
    {
        light = new GameObject();
        light.AddComponent<Light>();
        light.GetComponent<Light>().intensity = lightParameter / 2;
        light.GetComponent<Light>().range = 4*lightParameter + 1;
        light.transform.SetParent(transform);
        light.transform.position = transform.position + Vector3.up * (roomHeight - 0.2f);
    }
    public void CreateDoorFrames()
    {
        this.ChooseDoorLocations();

        northDoorFrame = Instantiate(doorFramePrefab);
        northDoorFrame.transform.SetParent(transform);
        northDoorFrame.transform.localPosition = new Vector3(northDoorLoc, 0, roomSize / 2f);
        northDoorFrame.transform.Rotate(Vector3.up, 180f);
        northDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.N);

        eastDoorFrame = Instantiate(doorFramePrefab);
        eastDoorFrame.transform.SetParent(transform);
        eastDoorFrame.transform.localPosition = new Vector3(roomSize / 2f, 0, eastDoorLoc);
        eastDoorFrame.transform.Rotate(Vector3.up, 270f);
        eastDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.E);

        southDoorFrame = Instantiate(doorFramePrefab);
        southDoorFrame.transform.SetParent(transform);
        southDoorFrame.transform.localPosition = new Vector3(southDoorLoc, 0, -roomSize / 2f);
        southDoorFrame.transform.Rotate(Vector3.up, 0f);
        southDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.S);

        westDoorFrame = Instantiate(doorFramePrefab);
        westDoorFrame.transform.SetParent(transform);
        westDoorFrame.transform.localPosition = new Vector3(-roomSize / 2f, 0, westDoorLoc);
        westDoorFrame.transform.Rotate(Vector3.up, 90f);
        westDoorFrame.GetComponent<DoorFrame>().CreatePortalTransform(Direction.W);
    }
    public void CreateWalls()
    {
        // North left
        wallNL = Instantiate(wallPrefab);
        wallNL.transform.SetParent(transform);
        wallNL.transform.localPosition = new Vector3((northDoorLoc - doorWidth/2f - wallLength/2f) / 2f, roomHeight / 2f, roomSize/2f);
        wallNL.transform.localScale = new Vector3(northDoorLoc - doorWidth / 2f + wallLength / 2f, roomHeight, 1f);
        wallNL.transform.Rotate(Vector3.up, 180f);
        walls.Add(wallNL);
        Debug.Log("wall at " + wallNL.transform.position);
        // North right
        wallNR = Instantiate(wallPrefab);
        wallNR.transform.SetParent(transform);
        wallNR.transform.localPosition = new Vector3((northDoorLoc + doorWidth / 2f + wallLength / 2f) / 2f, roomHeight / 2f, roomSize / 2f);
        wallNR.transform.localScale = new Vector3(wallLength/2f - northDoorLoc - doorWidth/2f, roomHeight, 1f);
        wallNR.transform.Rotate(Vector3.up, 180f);
        walls.Add(wallNR);

        // East left
        wallEL = Instantiate(wallPrefab);
        wallEL.transform.SetParent(transform);
        wallEL.transform.localPosition = new Vector3(roomSize / 2f, roomHeight / 2f, (eastDoorLoc - doorWidth / 2f - wallLength / 2f) / 2f);
        wallEL.transform.localScale = new Vector3(eastDoorLoc - doorWidth / 2f + wallLength / 2f, roomHeight, 1f);
        wallEL.transform.Rotate(Vector3.up, 270f);
        walls.Add(wallEL);
        // East right
        wallER = Instantiate(wallPrefab);
        wallER.transform.SetParent(transform);
        wallER.transform.localPosition = new Vector3(roomSize / 2f, roomHeight / 2f, (eastDoorLoc + doorWidth / 2f + wallLength / 2f) / 2f);
        wallER.transform.localScale = new Vector3(wallLength / 2f - eastDoorLoc - doorWidth / 2f, roomHeight, 1f);
        wallER.transform.Rotate(Vector3.up, 270f);
        walls.Add(wallER);

        // South left
        wallSL = Instantiate(wallPrefab);
        wallSL.transform.SetParent(transform);
        wallSL.transform.localPosition = new Vector3((southDoorLoc - doorWidth / 2f - wallLength / 2f) / 2f, roomHeight / 2f, -roomSize / 2f);
        wallSL.transform.localScale = new Vector3(southDoorLoc - doorWidth / 2f + wallLength / 2f, roomHeight, 1f);
        wallSL.transform.Rotate(Vector3.up, 0f);
        walls.Add(wallSL);
        // South right
        wallSR = Instantiate(wallPrefab);
        wallSR.transform.SetParent(transform);
        wallSR.transform.localPosition = new Vector3((southDoorLoc + doorWidth / 2f + wallLength / 2f) / 2f, roomHeight / 2f, -roomSize / 2f);
        wallSR.transform.localScale = new Vector3(wallLength / 2f - southDoorLoc - doorWidth / 2f, roomHeight, 1f);
        wallSR.transform.Rotate(Vector3.up, 0f);
        walls.Add(wallSR);

        // West left
        wallWL = Instantiate(wallPrefab);
        wallWL.transform.SetParent(transform);
        wallWL.transform.localPosition = new Vector3(-roomSize / 2f, roomHeight / 2f, (westDoorLoc - doorWidth / 2f - wallLength / 2f) / 2f);
        wallWL.transform.localScale = new Vector3(westDoorLoc - doorWidth / 2f + wallLength / 2f, roomHeight, 1f);
        wallWL.transform.Rotate(Vector3.up, 90f);
        walls.Add(wallWL);
        // West right
        wallWR = Instantiate(wallPrefab);
        wallWR.transform.SetParent(transform);
        wallWR.transform.localPosition = new Vector3(-roomSize / 2f, roomHeight / 2f, (westDoorLoc + doorWidth / 2f + wallLength / 2f) / 2f);
        wallWR.transform.localScale = new Vector3(wallLength / 2f - westDoorLoc - doorWidth / 2f, roomHeight, 1f);
        wallWR.transform.Rotate(Vector3.up, 90f);
        walls.Add(wallWR);

        // Door tops
        doorTopN = Instantiate(wallPrefab);
        doorTopN.transform.SetParent(transform);
        doorTopN.transform.localPosition = new Vector3(northDoorLoc, roomHeight - 0.5f, roomSize / 2f);
        doorTopN.transform.localScale = new Vector3(doorWidth, 1f, 1f);
        doorTopN.transform.Rotate(Vector3.up, 180f);
        walls.Add(doorTopN);

        doorTopE = Instantiate(wallPrefab);
        doorTopE.transform.SetParent(transform);
        doorTopE.transform.localPosition = new Vector3(roomSize/2f, roomHeight - 0.5f, eastDoorLoc);
        doorTopE.transform.localScale = new Vector3(doorWidth, 1f, 1f);
        doorTopE.transform.Rotate(Vector3.up, 270f);
        walls.Add(doorTopE);

        doorTopS = Instantiate(wallPrefab);
        doorTopS.transform.SetParent(transform);
        doorTopS.transform.localPosition = new Vector3(southDoorLoc, roomHeight - 0.5f, -roomSize / 2f);
        doorTopS.transform.localScale = new Vector3(doorWidth, 1f, 1f);
        doorTopS.transform.Rotate(Vector3.up, 0f);
        walls.Add(doorTopS);

        doorTopW = Instantiate(wallPrefab);
        doorTopW.transform.SetParent(transform);
        doorTopW.transform.localPosition = new Vector3(-roomSize / 2f, roomHeight - 0.5f, westDoorLoc);
        doorTopW.transform.localScale = new Vector3(doorWidth, 1f, 1f);
        doorTopW.transform.Rotate(Vector3.up, 270f);
        walls.Add(doorTopW);

        // Set the material of every wall
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].GetComponent<Renderer>().material = wallMat;
        }
    }
    public void CreateFloor()
    {
        floor = Instantiate(floorPrefab);
        floor.transform.localScale = new Vector3(roomSize/10f, 1f, roomSize/10f);
        floor.transform.position = transform.position;
        floor.GetComponent<Renderer>().material = floorMat;

        ceiling = Instantiate(wallPrefab);
        ceiling.transform.localScale = new Vector3(roomSize, 1f, roomSize);
        ceiling.transform.position = transform.position + Vector3.up * (roomHeight + 0.5f);
        ceiling.GetComponent<Renderer>().material = floorMat;
    }

    private void ChooseDoorLocations()
    {
        northDoorLoc = Random.Range(-wallLength / 2f + cornerBuffer, wallLength / 2f - cornerBuffer);
        eastDoorLoc = Random.Range(-wallLength / 2f + cornerBuffer, wallLength / 2f - cornerBuffer);
        southDoorLoc = Random.Range(-wallLength / 2f + cornerBuffer, wallLength / 2f - cornerBuffer);
        westDoorLoc = Random.Range(-wallLength / 2f + cornerBuffer, wallLength / 2f - cornerBuffer);
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
