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
    public float iOff, jOff;
    //gr
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        jOff+=0.1f;
        removeChildObjects();
        generate();
    }
    
    void removeChildObjects() {

            Transform transform;
            for(int i = 0;i < gameObject.transform.childCount; i++)
            {
            transform = gameObject.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);//The transform component is removed here, and an error will be reported when running.
            }

    }

    void generate() {
        
        for (float i = 0f; i < width; i++) for (float j = 0f; j < height; j++) {
            float noise = Mathf.PerlinNoise((i+(int)iOff)/scale + seed, (j+(int)jOff)/scale + seed);
            GameObject tile;
            if (noise > mThreshold) tile = mountainPrefab;
            else if (noise > gThreshold && false/*&& Random.Range(0f, 1f) > 0.5f*/) tile = pondPrefab;
            else if (noise > gThreshold) tile = grassPrefab;
            else if (noise > sThreshold) tile = sandPrefab;
            else tile = waterPrefab;

            float x = i * offset + offsetX * j%2;
            float y = j * offset;
            float z = noise > mThreshold ? mHeight : noise > gThreshold ? gHeight : noise > sThreshold ? sHeight : wHeight;
            GameObject tileObject = Instantiate(tile, new Vector3(x, z, y), Quaternion.identity) as GameObject;
            tileObject.transform.parent = gameObject.transform;
        }
    }
}
