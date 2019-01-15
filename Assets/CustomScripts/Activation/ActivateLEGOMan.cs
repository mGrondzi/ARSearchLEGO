using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ActivateLEGOMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGameObject(int pickedObject)
    {
        if (pickedObject == 2)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void toggleObjectTracker(int pickedObject)
    {
        if (pickedObject == 2)
        {
           // TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
            Debug.Log("Started LEGOMan Tracking");
        }
        else
        {
           // TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
            Debug.Log("Stoped LEGOMan Tracking");
        }
    }
}
