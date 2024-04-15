using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GolemSpawner : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image _cursor;
    [SerializeField] private Golem _prefab;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _cursor.gameObject.SetActive(true);
        _cursor.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _cursor.gameObject.SetActive(false);
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        var instance = Instantiate(_prefab, point, Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _cursor.transform.position = Input.mousePosition;
    }
}
