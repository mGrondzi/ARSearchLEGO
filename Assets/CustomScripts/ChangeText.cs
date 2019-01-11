using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public Text m_MyText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateCoordinateText(int x, int y, int z)
    {
       m_MyText.text = "Object detected on X: " + x + " Y: " + y + " Z: " + z;
    } 
}
