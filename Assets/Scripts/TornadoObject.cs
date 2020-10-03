using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoObject : MonoBehaviour
{
    public bool isStuck = false;
    public float rotateSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        if (isStuck)
            return;
        transform.RotateAround(Vector3.up, new Vector3(0, transform.position.y, 0), rotateSpeed * Time.deltaTime);
        transform.Rotate(transform.forward);
    }
}
