using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        float speedLimit = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speedLimit);
    }

}
