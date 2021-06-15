using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagonGenerator : MonoBehaviour
{
    public GameObject mountainPrefab, pondPrefab, grassPrefab, waterPrefab, sandPrefab;
    public int width, height, scale, seed;
    public float offset, offsetX;
    public float gThreshold, pThreshold, mThreshold, sThreshold;
    public float gHeight, mHeight, wHeight, sHeight;
    //gr
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] prefabs = new GameObject[5];
        prefabs[0] = mountainPrefab;
        prefabs[1] = pondPrefab;
        prefabs[2] = grassPrefab;
        prefabs[3] = waterPrefab;
        prefabs[4] = sandPrefab;
        for (float i = 0f; i < width; i++) for (float j = 0f; j < height; j++) {
            /*
            int random = (int)Random.Range(0f, 3f);
            random = random > 2 ? 2 : random < 0 ? 0 : random;
            */
            float noise = Mathf.PerlinNoise(i/scale + seed, j/scale + seed);
            Debug.Log(noise);
            GameObject tile;
            if (noise > mThreshold) tile = prefabs[0];
            else if (noise > gThreshold && Random.Range(0f, 1f) > 0.5f) tile = prefabs[1];
            else if (noise > gThreshold) tile = prefabs[2];
            else if (noise > sThreshold) tile = prefabs[4];
            else tile = prefabs[3];
            float x = i * offset + offsetX * j%2;
            float y = j * offset;
            float z = noise > mThreshold ? mHeight : noise > gThreshold ? gHeight : noise > sThreshold ? sHeight : wHeight;
            Instantiate(tile, new Vector3(x, z, y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
