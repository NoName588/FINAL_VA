using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REPITO : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - 32.8) {
        transform.position = startPos;
        }
    }
}
