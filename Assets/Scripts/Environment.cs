using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New environment", menuName = "Enviroments", order = 51)]
public class Environment : ShopItem
{
    [SerializeField] private Pipe _pipe;
    [SerializeField] private Background _background;
    [SerializeField] private Floor _floor;


    public Pipe Pipe => _pipe;
    public Background Background => _background;
    public Floor Floor => _floor;
}
