using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float projectileSpeed = 8f;
    public float fireRate = 0.9f;
    public GameObject projectilePrefab;

    private float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastFireTime > fireRate && Input.GetMouseButtonDown(0)) {
            // Shoot();
        }
    }

    void Shoot() {
        Rigidbody rigid = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * projectileSpeed;
        lastFireTime = Time.time;
    }
}
