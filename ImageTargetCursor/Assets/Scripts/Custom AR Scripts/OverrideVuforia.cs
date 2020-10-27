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
            cameraBGPlane.SetActive(enableBG);

            isBGFound = true;
        }
    }
}
