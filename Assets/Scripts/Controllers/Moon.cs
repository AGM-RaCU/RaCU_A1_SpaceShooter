using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    [Header("Orbit Properties")]
    public float radius;
    public float speed;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + (transform.position - target.position).normalized * radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            OrbitalMotion(radius, speed, target);
        }
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(target.transform.position, axis*radius, speed * Time.deltaTime);
    }
}
