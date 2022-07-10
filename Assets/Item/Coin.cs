using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemBase
{

    [SerializeField] private int _myScore;
 
    public override void Action()
    {
        Manager._instance.Score += _myScore;
    }
}
