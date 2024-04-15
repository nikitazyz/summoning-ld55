using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ResourceType _resourceType;

    private void Awake()
    {
        Game.Instance.ResourceBank.ValueChanged += (type, i) =>
        {
            if (type == _resourceType)
            {
                _text.text = i.ToString();
            }
        };
    }

    private void Start()
    {
        _image.sprite = Game.Instance.ResourceInfoManager.GetInfo(_resourceType).Icon;
        _text.text = Game.Instance.ResourceBank[_resourceType].ToString();
    }
} 
