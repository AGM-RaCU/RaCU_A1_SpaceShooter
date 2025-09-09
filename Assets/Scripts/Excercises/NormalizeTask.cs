using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizeTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(NormalizeVector(new Vector2(3, 4)));
        print(NormalizeVector(new Vector2(-3, 2)));
        print(NormalizeVector(new Vector2(1.5f, -3.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 NormalizeVector(Vector2 value)
    {
        float magnitude = value.magnitude;

        Vector2 normalized = new Vector2(value.x / magnitude, value.y / magnitude);
        return normalized;
    }
}
