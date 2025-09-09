using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMethods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vec = new Vector2(6, 18);

        float magnitude = MethodExamples.GetMagnitude(vec);

        print($"This is inside StaticMethods: {magnitude}");
    }

}
