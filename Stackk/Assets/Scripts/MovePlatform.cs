using System;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    float speed = 0.1f;
    Vector3 target;

    public static event Action<Vector3,Vector3> platformStops;


    void Start()
    {
        target = end;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (platformStops != null)
                platformStops(gameObject.transform.localScale, gameObject.transform.position);
            Destroy(this);
        }

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
