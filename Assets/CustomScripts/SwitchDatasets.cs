using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDatasets: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public void SwitchTargetByName(string activateThisDataset)
    {
        TrackerManager trackerManager = (TrackerManager)TrackerManager.Instance;
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

        IEnumerable<DataSet> datasets = objectTracker.GetDataSets();
        IEnumerable<DataSet> activeDataSets = objectTracker.GetActiveDataSets();
        List<DataSet> activeDataSetsToBeRemoved = activeDataSets.ToList();

        //Loop through all the active datasets and deactivate them.
        foreach (DataSet ads in activeDataSetsToBeRemoved)
        {
            objectTracker.DeactivateDataSet(ads);
        }

        //Swapping of the datasets should not be done while the ObjectTracker is working at the same time.
        //So, Stop the tracker first.
        objectTracker.Stop();

        //Then, look up the new dataset and if one exists, activate it.
        foreach (DataSet ds in datasets)
        {
            if (ds.Path.Contains(activateThisDataset))
            {
                objectTracker.ActivateDataSet(ds);
            }

        }
        //Finally, start the object tracker.
        objectTracker.Start();
    }*/
}
