using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileProperties : MonoBehaviour
{
    public GameObject tile; //assign your gameobject from the inspector here
    MeshFilter yourMesh;
    public Mesh model;

    public void setModel(GameObject Tile) {
        tile = Tile;

        MeshFilter yourMeshFilter = gameObject.GetComponent<MeshFilter>();
        yourMeshFilter.sharedMesh = tile.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;

        MeshRenderer yourMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        yourMeshRenderer.sharedMaterials = tile.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterials;
    }
}
