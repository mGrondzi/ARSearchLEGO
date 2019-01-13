using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorYellow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
