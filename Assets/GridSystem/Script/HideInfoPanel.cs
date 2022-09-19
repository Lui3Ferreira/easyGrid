using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInfoPanel : MonoBehaviour
{
    private float _delay = 3f; 
    void Start()
    {
        //Will hide the info panel after 3 seconds
        StartCoroutine(HideShowGO.ShowAndHide(gameObject, _delay, gameObject));
    }
}
