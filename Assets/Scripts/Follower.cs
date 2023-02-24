using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Vector3 followPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPos;
    // Start is called before the first frame update
    void Start()
    {
        parentPos = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        Watch();
        Move();
    }

    void Watch()
    {
        if (!parentPos.Contains(parent.position))
            parentPos.Enqueue(parent.position);

        if (parentPos.Count > followDelay)
            followPos = parentPos.Dequeue();
        else if (parentPos.Count < followDelay)
            followPos = parent.position;
    }

    void Move()
    {
        transform.position = followPos;

    }
}
