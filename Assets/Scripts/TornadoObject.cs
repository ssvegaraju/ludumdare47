using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoObject : MonoBehaviour
{
    public bool isStuck = false;
    public Vector2 rotateSpeed = new Vector2(25, 50);

    // Update is called once per frame
    void Update()
    {
        if (isStuck)
            return;
        float speed = Random.Range(rotateSpeed.x, rotateSpeed.y);
        transform.RotateAround(Vector3.up, new Vector3(0, transform.position.y, 0), speed * Time.deltaTime);
        transform.Rotate(transform.forward);
    }
}
