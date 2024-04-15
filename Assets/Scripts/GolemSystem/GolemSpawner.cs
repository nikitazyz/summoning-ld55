using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using CraftingSystem;
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
    [SerializeField] private LayerMask _spawnZone;
    [SerializeField] private Image _image;

    [SerializeField] private CraftReceipts _receipts;
    [SerializeField] private Image _receipt1;
    [SerializeField] private Image _receipt2;
    [SerializeField] private Image _receipt3;

    private bool _canUse;

    private void Awake()
    {
        _cursor.gameObject.SetActive(false);
        _inventory.ValueChanged += ValueChanged;
        _text.text = "x"+_inventory.GetCount(_prefab);

        var result =_receipts.GetReceiptByGameObject(_prefab);
        if (result == null)
        {
            return;
        }

        _receipt1.sprite = Game.Instance.ResourceInfoManager.GetInfo(result[0]).Small;
        _receipt2.sprite = Game.Instance.ResourceInfoManager.GetInfo(result[1]).Small;
        _receipt3.sprite = Game.Instance.ResourceInfoManager.GetInfo(result[2]).Small;
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
        _cursor.sprite = _image.sprite;
        _cursor.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        _cursor.gameObject.SetActive(false);
        if (!_canUse || 
            EventSystem.current.IsPointerOverGameObject() || 
            !Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), _spawnZone))
        {
            return;
        }
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        var instance = Instantiate(_prefab, point, Quaternion.identity);
        _inventory.Use(_prefab);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Color c = _cursor.color;
        if (EventSystem.current.IsPointerOverGameObject() || 
            !Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), _spawnZone))
        {
            c.a = 0.5f;
        }
        else
        {
            c.a = 1;
        }

        _cursor.color = c;
        
        _cursor.transform.position = Input.mousePosition;
    }
}
