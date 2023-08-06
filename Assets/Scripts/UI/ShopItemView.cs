using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _selectButton;

    private ShopItem _item;

    public event UnityAction<ShopItem, ShopItemView> SellButtonClick;
    public event UnityAction<ShopItem> SelectButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _selectButton.onClick.AddListener(OnSelectButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _selectButton.onClick.RemoveListener(OnSelectButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);        
    }

    public void Render(ShopItem item)
    {
        _item = item;
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Icon;
        TryLockItem();
    }

    private void TryLockItem()
    {
        if (_item.IsBought)
        {
            _sellButton.gameObject.SetActive(false);
            _cost.gameObject.SetActive(false);
            _sellButton.gameObject.SetActive(true);
        }
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
    }

    private void OnSelectButtonClick()
    {
        SelectButtonClick?.Invoke(_item);
    }
}
