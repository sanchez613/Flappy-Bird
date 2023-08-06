using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Environment _currentEnvironment;
    private Skin _currentSkin;

    public int Money { get; private set; } = 200;

    public event UnityAction<Skin> SkinChange;
    public event UnityAction<Environment> EnvironmentChange;

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyItem(ShopItem item)
    {
        Money -= item.Cost;
        SetItem(item);
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
