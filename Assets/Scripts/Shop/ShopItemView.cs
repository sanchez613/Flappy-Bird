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
        Invoke(nameof(DisplayButton), 0);        
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
        _sellButton.gameObject.SetActive(false);
        _cost.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(false);
    }

    public void Render(ShopItem item)
    {
        _item = item;
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Icon;
        TryLockItem();
    }

    private void DisplayButton() 
    {
        if (_item.IsBought)
        {
            _selectButton.gameObject.SetActive(true);
            _selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        else
        {
            _sellButton.gameObject.SetActive(true);
            _cost.gameObject.SetActive(true);
            _sellButton.onClick.AddListener(OnSellButtonClick);
            _sellButton.onClick.AddListener(TryLockItem);
        }
    }

    private void TryLockItem()
    {
        if (_item.IsBought)
        {
            _sellButton.gameObject.SetActive(false);
            _cost.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
        }
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
        TryLockItem();
    }

    private void OnSelectButtonClick()
    {
        SelectButtonClick?.Invoke(_item);
    }
}
