/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// 
/// Changes made to this file could be overwritten when upgrading the Vuforia version. 
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class ColorTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;


    #endregion // PROTECTED_MEMBER_VARIABLES

    public Text m_MyText;
    private RenderTexture renderTexture;

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            this.TakeScreenShotOfObject();
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS



    private void TakeScreenShotOfObject()
    {
        Camera mainCamera = Camera.main.GetComponent<Camera>();
        Vector3 objectTargetPosition = mainCamera.WorldToScreenPoint(mTrackableBehaviour.transform.position);

        
        //GameObject.Find("Canvas").GetComponents<Canvas>().enabled = false;
        //yield return new WaitForEndOfFrame();
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            renderTexture = new RenderTexture(mainCamera.pixelWidth, mainCamera.pixelHeight, 24);
            mainCamera.targetTexture = renderTexture;
            RenderTexture.active = renderTexture;
            mainCamera.Render();
            Texture2D m_Texture = new Texture2D(mainCamera.pixelWidth, mainCamera.pixelHeight, TextureFormat.RGB24, false);
            m_Texture.ReadPixels(new Rect(0, 0, mainCamera.pixelWidth, mainCamera.pixelHeight), 0, 0);
            m_Texture.Apply();
            Debug.Log("X: " + objectTargetPosition.x + " Y: " + objectTargetPosition.y);

            this.m_MyText.text = "X: " + objectTargetPosition.x + " Y: " + objectTargetPosition.y;
            //Texture2D m_Texture = new Texture2D(mainCamera.pixelWidth, mainCamera.pixelHeight, TextureFormat.RGBA32, false);
           // m_Texture.ReadPixels(new Rect(0, 0, mainCamera.pixelWidth, mainCamera.pixelHeight), 0, 0, true);
          //  m_Texture.Apply();

            // mainCamera = Camera.main.GetComponent<Camera>();
            //Texture2D m_Texture = new Texture2D(mainCamera.pixelWidth, mainCamera.pixelHeight, TextureFormat.RGBA32, false);
            //RenderTexture currentRT = RenderTexture.active;
            //RenderTexture renderTexture = new RenderTexture(mainCamera.pixelWidth, mainCamera.pixelHeight, 32);
            //Graphics.Blit(m_Texture, renderTexture);
            //RenderTexture.active = renderTexture;
            //m_Texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), (int)objectTargetPosition.x, (int)objectTargetPosition.y);
            Color screenshot = m_Texture.GetPixel((int)objectTargetPosition.x, (int)objectTargetPosition.y);
            //RenderTexture renderTex = new RenderTexture(Screen.width, Screen.height, 24);
            //mainCamera.targetTexture = renderTex;
            //RenderTexture.active = renderTex;
            //mainCamera.Render();
            //Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            //screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), (int)objectTargetPosition.x, (int)objectTargetPosition.y);
            //Graphics.Blit(mainTexture, renderTexture);
            //screenshot.Apply();
            //Color pixelColor = screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), (int)objectTargetPosition.x, (int)objectTargetPosition.y);
           // Color pixelColor = screenshot.GetPixel((int)objectTargetPosition.x, Screen.height - (int)objectTargetPosition.y);
            Debug.Log("Color: " + screenshot.ToString());
            RenderTexture.active = null;
            mainCamera.targetTexture = null;
        }
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {

        }

        //Vector3 objectTargetPosition = cam.WorldToScreenPoint(mTrackableBehaviour.transform.position);
        //Debug.Log("Object detected on X: " + objectTargetPosition.x + " Y: " + objectTargetPosition.y);
        //m_MyText.text = "X: " + objectTargetPosition.x + " Y: " + objectTargetPosition.y;

        //Debug.Log("Screen width " + mainCamera.pixelWidth + " Screen height:" + mainCamera.pixelHeight);
        //Texture2D m_Texture = new Texture2D(mainCamera.pixelWidth, mainCamera.pixelHeight, TextureFormat.RGBA32, false);
        //RenderTexture currentRT = RenderTexture.active;
        //RenderTexture renderTexture = new RenderTexture(cam.pixelWidth, cam.pixelHeight, 32);
        //Graphics.Blit(mainTexture, renderTexture);


//        RenderTexture.active = renderTexture;

       // Debug.Log("Screen width " + mainCamera.pixelWidth + " Screen height:" + mainCamera.pixelHeight);
       // m_Texture.ReadPixels(new Rect(0, 0, 1, 0),(int) objectTargetPosition.x,(int) objectTargetPosition.y);
        //m_Texture.ReadPixels(new Rect(objectTargetPosition.x, objectTargetPosition.y, objectTargetPosition.x +1, objectTargetPosition.y+1), 0, 0, true); //create the Pixels need to get Position of LEGO Stone
       // m_Texture.Apply();
       // Debug.Log(m_Texture.GetPixel(0,0).ToString());
       // Debug.Log(m_Texture.GetPixel((int)objectTargetPosition.x, (int)objectTargetPosition.y).b);
       // Debug.Log(m_Texture.GetPixel((int)objectTargetPosition.x, (int)objectTargetPosition.y).g);
    }
}
