using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Vector3 followPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPosQueue;
    // Start is called before the first frame update
    void Start()
    {
        parentPosQueue = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        Watch();
        Move();
    }

    void Watch()
    {
        if (!parentPosQueue.Contains(parent.position))
        {
            parentPosQueue.Enqueue(parent.position);
            Debug.Log(parent.position);
        }
            

        if (parentPosQueue.Count > followDelay)
            followPos = parentPosQueue.Dequeue();
        else if (parentPosQueue.Count < followDelay)
            followPos = parent.position;


        
    }

    void Move()
    {
        transform.position = followPos;

    }
}
