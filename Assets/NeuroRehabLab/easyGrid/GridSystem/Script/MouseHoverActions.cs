using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   [SerializeField]
    private GameObject _infoPanePrefab;
    private GameObject _info;
    [SerializeField]
     private int xPos,yPos,zPos;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _info = Instantiate(_infoPanePrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        _info.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(_info);
    }
}
