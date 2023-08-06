using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> _shopItems;
    [SerializeField] private Player _player;
    [SerializeField] private ShopItemView _itemView;
    [SerializeField] private GameObject _itemContainer;

    private void OnEnable()
    {
        _itemView.SelectButtonClick += OnSelectButtonClick;
    }

    private void OnDisable()
    {
        _itemView.SelectButtonClick -= OnSelectButtonClick;
    }

    private void Start()
    {
        for (int i = 0; i < _shopItems.Count; i++)
        {
            AddItem(_shopItems[i]);
        }
    }

    private void AddItem(ShopItem shopItem)
    {
        var view = Instantiate(_itemView, _itemContainer.transform);
        view.SellButtonClick += OnSellButtoClick;
        view.Render(shopItem);
    }

    private void OnSellButtoClick(ShopItem item, ShopItemView itemView)
    {
        TrySellItem(item, itemView);
    }

    private void OnSelectButtonClick(ShopItem item)
    {
        _player.SetItem(item);
    }

    private void TrySellItem(ShopItem item, ShopItemView itemView)
    {
        if(item.Cost <= _player.Money)
        {
            _player.BuyItem(item);
            item.Buy();
            itemView.SellButtonClick -= OnSellButtoClick;
        }
    }
}
