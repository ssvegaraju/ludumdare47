using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoManager : MonoBehaviour
{
    public int levels = 15;
    [Tooltip("Controls the height difference between levels")]
    public float levelHeight = 1.5f;
    public int baseLevelRadius = 5;
    public int levelMultiplier = 3;
    public GameObject[] objectPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        GenerateDebris();
    }

    [ContextMenu("Generate")]
    void GenerateDebris() {
        for (int i = 0; i < levels; i++) {
            int radius = baseLevelRadius * (i + 1);
            for (int j = 0; j < i * levelMultiplier; j++) {
                int rand = Random.Range(0, objectPrefabs.Length);
                Vector3 spawnPos = Random.onUnitSphere * radius;
                spawnPos.y = i * levelHeight;
                GameObject obj = Instantiate(objectPrefabs[rand], spawnPos, Random.rotation, transform);
            }
        }
    }

    [ContextMenu("Delete Debris")]
    void DeleteDebris() {
        int deleteCount = transform.childCount;
        for (int i = 0; i < deleteCount; i++) {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
