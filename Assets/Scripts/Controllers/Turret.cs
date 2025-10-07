using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed = 60f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, angularSpeed * Time.deltaTime);

        Vector2 directionToTarget = (target.position - transform.position).normalized;

        float dot = Vector3.Dot(transform.up, directionToTarget);


        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);
        Debug.DrawLine(transform.position, transform.position + (Vector3)directionToTarget, Color.magenta);

        if (dot < 0) Debug.Log($"<color=red><size=16>Behind!</size></color>");
        if (dot > 0) Debug.Log($"<color=cyan><size=16>InFront!</size></color>");
    }
}
