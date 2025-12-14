using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target.position = new Vector3(transform.position.x * Random.Range(-1, 1) * maxFloatDistance, transform.position.y * Random.Range(1, -1) * maxFloatDistance, 0);

        Debug.Log(target.position);
    }

    // Update is called once per frame
    void Update()
    { 
    
        //targetPosition = new Vector3(transform.position.x * Random.Range(1, 5) * maxFloatDistance, transform.position.y * Random.Range(1, 5) * maxFloatDistance, 0);

        //target.position = targetPosition;

        //Debug.Log(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);

        float distance = Vector3.Distance(target.position, transform.position);

        Debug.Log(distance);

        if (arrivalDistance >= distance)
        {
            transform.position = new Vector3(Random.Range(-10, 10), Random.Range(10, -10), 0);
            target.position = new Vector3(transform.position.x * Random.Range(-1, 1) * maxFloatDistance, transform.position.y * Random.Range(1, -1) * maxFloatDistance, 0);
        }


    }
}
