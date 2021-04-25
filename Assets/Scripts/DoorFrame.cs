using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { N, S, E, W };

public class DoorFrame : MonoBehaviour
{
    private GameObject portalTransform;

    public GameObject portalTransformN;
    public GameObject portalTransformE;
    public GameObject portalTransformS;
    public GameObject portalTransformW;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePortalTransform(Direction dir)
    {
        if(dir == Direction.N)
        {
            portalTransform = Instantiate(portalTransformN);
        }
        else if (dir == Direction.E)
        {
            portalTransform = Instantiate(portalTransformE);
        }
        else if (dir == Direction.S)
        {
            portalTransform = Instantiate(portalTransformS);
        }
        else
        {
            portalTransform = Instantiate(portalTransformW);
        }
        portalTransform.transform.position = transform.position + transform.up * 2f;
    }

    public Transform GetPortalTransform()
    {
        return portalTransform.transform;
    }
}
