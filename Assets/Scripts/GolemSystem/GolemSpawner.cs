using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GolemSpawner : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image _cursor;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Inventory _inventory;

    private bool _canUse;

    private void Awake()
    {
        _cursor.gameObject.SetActive(false);
        _inventory.ValueChanged += ValueChanged;
        _text.text = "x"+_inventory.GetCount(_prefab);
    }

    private void ValueChanged(GameObject element, int count)
    {
        if (element != _prefab)
        {
            return;
        }
        _text.text = "x"+count.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _canUse = _inventory.CanUse(_prefab);
        if (!_canUse)
        {
            return;
        }
        _cursor.gameObject.SetActive(true);
        _cursor.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_canUse)
        {
            return;
        }
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
