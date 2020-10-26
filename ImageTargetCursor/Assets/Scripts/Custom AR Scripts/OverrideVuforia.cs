using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideVuforia : MonoBehaviour
{
    private GameObject cameraBGPlane;
    private bool isBGFound = false;

    private void Update()
    {
        if(transform.childCount > 1 && !isBGFound)
        {
            cameraBGPlane = transform.GetChild(1).gameObject;
            cameraBGPlane.SetActive(false);

            isBGFound = false;        
        }
    }
}
