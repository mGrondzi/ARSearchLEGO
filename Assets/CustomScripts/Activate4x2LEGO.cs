using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate4x2LEGO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleGameObject(int pickedObject)
    {
        if (pickedObject == 1)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
