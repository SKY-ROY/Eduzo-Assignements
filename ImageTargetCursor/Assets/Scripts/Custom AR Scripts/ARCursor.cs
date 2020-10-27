using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARCursor : MonoBehaviour
{
    public GameObject cursorObject;

    private GameObject ARCamera;
    private BaseController playerController;

    private bool horizontalMovementReset = false;
    private bool verticalMovementReset = false;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).GetComponent<BaseController>();
        ARCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        ButtonDetection();
    }
    
    void ButtonDetection()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(ARCamera.transform.position, cursorObject.transform.position - ARCamera.transform.position);

        Debug.DrawRay(ARCamera.transform.position, cursorObject.transform.position - ARCamera.transform.position, Color.red);

        if (Physics.Raycast(landingRay, out hit))
        {
            
            if(hit.collider.tag == MyTags.ARUpCollider_TAG)
            { 
                Debug.Log("UP!");
                playerController.UpwardMovement();
                verticalMovementReset = true;
            }
            if (hit.collider.tag == MyTags.ARDownCollider_TAG)
            {
                Debug.Log("DOWN!");
                playerController.DownwardMovement();
                verticalMovementReset = true;
            }
            if (hit.collider.tag == MyTags.ARRightCollider_TAG)
            {
                Debug.Log("RIGHT!");
                playerController.RightTurnMovement();
                horizontalMovementReset = true;
            }
            if (hit.collider.tag == MyTags.ARLeftCollider_TAG)
            {
                Debug.Log("LEFT!");
                playerController.LeftTurnMovement();
                horizontalMovementReset = true;
            }
            if (hit.collider.tag == MyTags.ARNormalCollider_TAG)
            {
                Debug.Log("NORMAL!");
                if(horizontalMovementReset)
                {
                    playerController.StraightMovement();
                    horizontalMovementReset = false;
                }
                if(verticalMovementReset)
                {
                    playerController.NormalMovement();
                    verticalMovementReset = false;
                }
            }
        }
        else
        {
            Debug.Log("Rays are not hitting anything!");
        }
    }
}
