using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagonGenerator : MonoBehaviour
{
    public GameObject mountainPrefab, forestPrefab, grassPrefab, waterPrefab, sandPrefab, desertPrefab;
    public int width, height, scale, seed;
    public float offset, offsetX;
    public float gThreshold, fThreshold, mThreshold, sThreshold, desertThreshold;
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
        if (Input.GetKey(KeyCode.W)) jOff+=0.5f;
        if (Input.GetKey(KeyCode.S)) jOff-=0.5f;
        if (Input.GetKey(KeyCode.D)) iOff+=0.5f;
        if (Input.GetKey(KeyCode.A)) iOff-=0.5f;
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
            float biomeNoise = Mathf.PerlinNoise((i+(int)iOff)/scale + seed + 1000, (j+(int)jOff)/scale + seed + 1000);
            GameObject tile;
            if (noise > mThreshold) tile = mountainPrefab;
            else if (noise > gThreshold) {
                if (biomeNoise > fThreshold) tile = forestPrefab;
                else if (biomeNoise < desertThreshold) tile = desertPrefab;
                else tile = grassPrefab;
            }
            else if (noise > sThreshold) tile = sandPrefab;
            else tile = waterPrefab;

            float x = i * offset + offsetX * j%2;
            float y = j * offset;
            float z = noise > mThreshold ? noise+0.2f : noise > gThreshold ? gHeight : noise > sThreshold ? sHeight : wHeight;
            GameObject tileObject = Instantiate(tile, new Vector3(x, z, y), Quaternion.identity) as GameObject;
            tileObject.transform.parent = gameObject.transform;
            /*Debug.Log((int)(Mathf.PerlinNoise((i+(int)iOff)/(scale*10), (j+(int)jOff)/(scale*10))*4)*90.0f);
            tileObject.transform.Rotate(0.0f, (int)(Mathf.PerlinNoise((i+(int)iOff)/(scale*10), (j+(int)jOff)/(scale*10))*4)*90.0f, 0.0f, Space.Self);*/
        }
    }
}
