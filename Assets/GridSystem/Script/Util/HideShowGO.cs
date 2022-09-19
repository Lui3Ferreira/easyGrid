using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowGO : MonoBehaviour
{
    //This function can be called everywhere in the code to hide GO after certain time frame
    public static IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    public static IEnumerator ShowAndHide(GameObject go, float delay, GameObject destroyGameObject)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
        Destroy(destroyGameObject);
    }
}
