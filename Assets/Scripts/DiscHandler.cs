using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Disc))]
public class DiscHandler : MonoBehaviour
{
    public float animTime = 0.3f;
    public AnimationCurve curve;
    private Disc disc;
    // Start is called before the first frame update
    void Start()
    {
        disc = GetComponent<Disc>();
        Spawn();
    }

    [ContextMenu("Test Spawn Anim")]
    public void Spawn() {
        StartCoroutine(SpawnAnim());
    }

    private IEnumerator SpawnAnim() {
        float startTime = Time.time;
        while (Time.time - startTime <= 0.3f) {
            disc.AngRadiansEnd = 2 * Mathf.PI * curve.Evaluate(Time.time - startTime);
            transform.localScale = Vector3.one * curve.Evaluate(Time.time - startTime);
            Debug.Log(Time.time - startTime);
            yield return null;
        }
    }

}
