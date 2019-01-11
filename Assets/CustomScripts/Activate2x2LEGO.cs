using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate2x2LEGO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleGameObject(int pickedObject)
    {
        if (pickedObject == 0)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
