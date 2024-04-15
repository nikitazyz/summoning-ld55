using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;

    private bool _value;

    public bool IsOpen => _value;

    private void Awake()
    {
        _button.onClick.AddListener(ToggleInventory);
        _animator.SetBool("Open", _value);
    }

    public void ToggleInventory()
    {
        _value = !_value;
        _animator.SetBool("Open", _value);
        Time.timeScale = _value ? 0 : 1;
    }
}
