using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
