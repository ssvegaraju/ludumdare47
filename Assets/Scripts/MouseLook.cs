using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public GameObject spawnDisc;

    public float targetDistance = 150f;

    public LayerMask freezeLayer;

    public Disc targetReticle;

    public int maxFreezes = 3;

    private List<Freezable> frozenObjects = new List<Freezable>();
    
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
            targetReticle.Color = Color.green;
            if (Input.GetMouseButtonDown(0)) {
                freezeObject(hit.transform.gameObject.GetComponent<TornadoObject>());
            }
        } else {
            targetReticle.Color = Color.white;
        }
    }

    private void freezeObject(TornadoObject target) {
        if (target.isStuck) { // is stuck
            Freezable f = frozenObjects.Find(x => x.obj == target);
            f.Delete();
            frozenObjects.Remove(f);
        } else { // stuckify the object
            if (frozenObjects.Count >= maxFreezes) {
                frozenObjects[0].Delete();
                frozenObjects.RemoveAt(0);
            }
            frozenObjects.Add(new Freezable(target,
                Instantiate(spawnDisc, target.transform.position, Quaternion.identity, target.transform)));
        }
    }

    private struct Freezable
    {
        public TornadoObject obj;
        public GameObject particle;

        public Freezable(TornadoObject obj, GameObject particle) {
            this.obj = obj;
            this.particle = particle;
            obj.isStuck = true;
        }

        public void Delete() {
            obj.isStuck = false;
            Destroy(particle);
        }
    }
}

