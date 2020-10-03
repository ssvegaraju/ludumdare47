using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public float targetDistance = 150f;

    public LayerMask freezeLayer;

    public GameObject targetReticle;

    public int maxFreezes = 3;

    private List<TornadoObject> frozenObjects = new List<TornadoObject>();
    
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        targetObject();
    }

    private void targetObject() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, targetDistance, freezeLayer)) {
            targetReticle.SetActive(true);
            if (Input.GetMouseButtonDown(0)) {
                freezeObject(hit.transform.gameObject.GetComponent<TornadoObject>());
            }
        } else {
            targetReticle.SetActive(false);
        }
    }

    private void freezeObject(TornadoObject target) {
        if (target.isStuck) { // is stuck
            frozenObjects.Remove(target);
        } else { // stuckify the object
            if (frozenObjects.Count >= maxFreezes) {
                frozenObjects[0].isStuck = false;
                frozenObjects.RemoveAt(0);
            }
            frozenObjects.Add(target);
        }
        target.isStuck = !target.isStuck;
    }
}
