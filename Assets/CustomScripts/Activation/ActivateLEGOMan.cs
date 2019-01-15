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
        //VuforiaARController.Instance.RegisterVuforiaStartedCallback(SwapActiveDatasets);
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
            //SwapActiveDatasets();
            Debug.Log("Stoped LEGOMan Tracking");
        }
    }

    private void SwapActiveDatasets()
    {
        // ObjectTracker tracks targets contained in a DataSet and provides methods for creating and (de)activating datasets.
        string datasetToActivate = "Test";
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        IEnumerable<DataSet> datasets = objectTracker.GetDataSets();

        IEnumerable<DataSet> activeDataSets = objectTracker.GetActiveDataSets();
        List<DataSet> activeDataSetsToBeRemoved = activeDataSets.ToList();

        // 1. Loop through all the active datasets and deactivate them.
        foreach (DataSet ads in activeDataSetsToBeRemoved)
        {
            objectTracker.DeactivateDataSet(ads);
        }

        // Swapping of the datasets should NOT be done while the ObjectTracker is running.
        // 2. So, Stop the tracker first.
        objectTracker.Stop();

        // 3. Then, look up the new dataset and if one exists, activate it.
        foreach (DataSet ds in datasets)
        {
            if (ds.Path.Contains(datasetToActivate))
            {
                objectTracker.ActivateDataSet(ds);
            }
        }

        // 4. Loop through the trackable behaviours and set the GuideView.
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        foreach (TrackableBehaviour tb in tbs)
        {
            if (tb is ModelTargetBehaviour && tb.isActiveAndEnabled)
            {
                Debug.Log("TrackableName: " + tb.TrackableName);
                (tb as ModelTargetBehaviour).GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.GuideView2D;
            }

        }

        // 5. Finally, restart the object tracker.
        objectTracker.Start();
    }

}
