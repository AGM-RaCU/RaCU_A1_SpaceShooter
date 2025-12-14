using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBombs : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        float speedLimit = speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedLimit*Time.deltaTime);
        Debug.DrawLine(transform.position, target.position, Color.red);



    }
}
