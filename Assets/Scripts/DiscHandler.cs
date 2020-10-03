using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Disc))]
public class DiscHandler : MonoBehaviour
{
    public float animTime = 0;
    public AnimationCurve curve;
    private Disc disc;
    // Start is called before the first frame update
    void Start()
    {
        disc = GetComponent<Disc>();
        animTime = 0;
        Spawn(0);
    }

    [ContextMenu("Test Spawn Anim")]
    public void Spawn(int radius) {

    }

}
