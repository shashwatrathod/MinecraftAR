using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

/*
 * #0 - Dirt
 * #1 - Grass
 * #2 - Rock
 * #3 - Wood
 * */

public class ARTapToPlace : MonoBehaviour
{

    public static int material = 0;
    [SerializeField] public GameObject[] objectToPlace;
    public GameObject placementIndicator;
    private Camera myCamera;
    private ARSessionOrigin arOrigin;
    private ARRaycastManager raycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    List<Pose> poses;
    ObjectSelector objSel;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        raycastManager = FindObjectOfType<ARRaycastManager>();
        poses = new List<Pose>();
        /* var cameraForward = Camera.current.transform.forward;
         var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
         var rot = Quaternion.LookRotation(cameraBearing);
         placementPose = new Pose(Camera.main.ViewportToScreenPoint(new Vector3(12f, 12f)),rot);
         placementPose.position.z = Mathf.Clamp(placementPose.position.z, 10f, Mathf.Infinity);
         placementIndicator.SetActive(true);
         */


        Debug.Log("Hello World!");
        objSel.currOpt = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("UICompSelectScene");
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        //int material = objSel.getCurrOption();
        foreach (var t in Input.touches)
        {
            if (t.phase != TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
                {
                    Instantiate(objectToPlace[material], hitInfo.transform.gameObject.transform.position + new Vector3(0.06f, 0.06f, 0.06f), Quaternion.identity);
                    poses.Add(placementPose);
                }
            }
        }

    }

  /*  private void UpdatePlacementIndicator()
    {
        placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    } */

    private void PlaceObject()
    {
        Instantiate(objectToPlace[material], placementPose.position, placementPose.rotation);
        poses.Add(placementPose);
    }

    

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        Debug.Log(hits);



        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
       
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            Debug.Log(placementPose);
            //placementPose = new Pose(new Vector3(1f, 1f), new Quaternion(1, 2, 3, 4));

            
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

   public void OnPointerDown(PointerEventData eventDate)
    {

    }

    public void OnPointerUp(PointerEventData eventDate)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /* var ray = Camera.main.ScreenPointToRay(eventData.position);
         RaycastHit hitInfo;

         if (Physics.Raycast(ray, out hitInfo))
         {
             Instantiate(objectToPlace, hitInfo.point, Quaternion.identity);
             poses.Add(placementPose); */
        //}
    }
        /*
        private void UpdatePlacementPose()
        {
            var ray = Camera.main.ScreenPointToRay(placementPose.position);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, Mathf.Infinity);
            placementPose.position = hitInfo.point;
            placementPose.position.z = Mathf.Clamp(placementPose.position.z, 10f, Mathf.Infinity);
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);

        }
        */
    

}
