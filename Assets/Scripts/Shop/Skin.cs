using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New skin", menuName = "Skins", order = 51)]
public class Skin : ShopItem
{
    [SerializeField] private SpriteRenderer _renderer;

    public SpriteRenderer Renderer => _renderer;
}
