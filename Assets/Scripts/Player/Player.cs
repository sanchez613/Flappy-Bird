using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Environment _currentEnvironment;
    private Skin _currentSkin;
    private Wallet _wallet = new();

    public int Money => _wallet.Money;

    public event UnityAction<Skin> SkinChange;
    public event UnityAction<Environment> EnvironmentChange;

    public void AddMoney(int money)
    {
        if(money > 0)
            _wallet.AddMoney(money);
    }

    public bool TryBuyItem(ShopItem item)
    {
        if (_wallet.Pay(item.Cost))
        {
            item.Buy();
            SetItem(item);
            return true;
        }

        return false;
    }

    public void SetItem(ShopItem item)
    {
        if (item is Skin skin)
        {
            _currentSkin = skin;
            SkinChange?.Invoke(_currentSkin);
        }
        else if (item is Environment environment)
        {
            _currentEnvironment = environment;
            EnvironmentChange?.Invoke(_currentEnvironment);
        }
    }
}
