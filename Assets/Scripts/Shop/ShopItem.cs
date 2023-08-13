using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isBought;

    public bool IsBought => _isBought;
    public int Cost => _cost;
    public Sprite Icon => _icon;

    public void Buy()
    {
        _isBought = true;
    }
}
