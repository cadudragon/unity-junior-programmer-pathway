using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float scaleMultipler = 1.3f;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
    
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.localScale = Vector3.one * scaleMultipler;
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
