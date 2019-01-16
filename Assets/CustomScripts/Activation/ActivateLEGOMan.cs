using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class ActivateLEGOMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent(ObjectTargetBehaviour).enabled = false;
        //VuforiaARController.Instance.RegisterVuforiaStartedCallback(SwapActiveDatasets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGameObject(int pickedObject)
    {
        if (pickedObject == 2){
            gameObject.SetActive(true);
           // this.oTB.enabled = true;
        }
        else{
            gameObject.SetActive(false);
           // gameObject.GetComponent<ObjectTargetBehaviour>().enabled = false;
           // this.oTB.enabled = false;
        }
    }

}
