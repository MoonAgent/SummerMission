using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControler : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
