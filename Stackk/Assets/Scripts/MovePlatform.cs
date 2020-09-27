using System;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    float speed = 0.1f;
    Vector3 target;

    public event Action<Vector3> platformStops;

    [SerializeField] bool isMoving = true;

    void Start()
    {
        target = end;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   isMoving = false;
            if (platformStops != null)
            {
                platformStops(transform.position);
                platformStops = null;
            }
        }
        if (isMoving)
        {
            if (transform.position != target)
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            else
            {
                if (target == end)
                    target = start;
                else
                    target = end;
            }
        }    
    }
}
