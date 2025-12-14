using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSystem : MonoBehaviour
{
    public float angularSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        float angleStep = angularSpeed * Time.deltaTime;

        transform.Rotate(0, 0, angleStep);

    }


}
