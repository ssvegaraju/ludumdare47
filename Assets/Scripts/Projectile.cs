using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifeTime) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        TornadoObject obj = collision.gameObject.GetComponent<TornadoObject>();
        if (obj == null) {
            return;
        }
        obj.isStuck = true;
        // Spawn Particles and stuff here.
        Destroy(gameObject);
    }
}
