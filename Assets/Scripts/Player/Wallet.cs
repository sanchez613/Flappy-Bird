using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public int Money { get; private set; } = 200;

    public void AddMoney(int money)
    {
        Money += money;
    }

    public bool Pay(int money)
    {
        if (Money >= money)
        {
            Money -= money;
            return true;
        }

        return false;
    }
}
