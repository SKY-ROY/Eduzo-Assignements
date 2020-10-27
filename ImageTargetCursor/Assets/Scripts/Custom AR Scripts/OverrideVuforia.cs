using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideVuforia : MonoBehaviour
{
    public bool enableBG = false;

    private GameObject cameraBGPlane;
    private bool isBGFound = false;

    private void Update()
    {
        if(transform.childCount > 1 && !isBGFound)
        {
            cameraBGPlane = transform.GetChild(1).gameObject;
            Debug.Log("Object Found");
        
            cameraBGPlane.gameObject.transform.localPosition = new Vector3(-0.625f, 0f, 1.5f);
            cameraBGPlane.gameObject.transform.localScale = new Vector3(0.125f, 1f, 0.09f);
            //isBGFound = true;
        }
    }
}
