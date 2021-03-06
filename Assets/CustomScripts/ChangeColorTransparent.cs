﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTransparent : MonoBehaviour {

    Renderer rend;
    // Use this for initialization
    void Start()
    {

        rend = GetComponent<Renderer>();
        //Set the main Color of the Material to green
        // rend.material.shader = Shader.Find("_Color");
        //rend.material.SetColor("_Color", Color.red);
        this.MakeShapeTransparent();

        //Find the Specular shader and change its Color to red
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", Color.red);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeColorFloat(float colorPick)
    {
        rend = GetComponent<Renderer>();

        if (colorPick <= 1)
            rend.material.SetColor("_Color", Color.red);
        else if (colorPick <= 2)
            rend.material.SetColor("_Color", Color.blue);
        else if (colorPick <= 3)
            rend.material.SetColor("_Color", Color.green);
        else if (colorPick <= 4)
            rend.material.SetColor("_Color", Color.yellow);

        this.MakeShapeTransparent();
    }

    private void MakeShapeTransparent()
    {
        Material material = rend.material;

        material.SetFloat("_Mode", 3f);


        Color color = material.color;
        color.a -= 0.69f;
        material.SetColor("_Color", color);
    }
}
