using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    bool isMoving = true;

    float speed = 0.1f;
    Vector3 target;

    void Start()
    {
        target = end;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if(transform.position != target)
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
