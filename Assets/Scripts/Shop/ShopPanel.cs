using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyDispley;

    public void DisplayMoney(int money)
    {
        _moneyDispley.text = money.ToString();
    }
}
