using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : ItemBase
{

    [SerializeField] private int _myLife;

    public override void Action()
    {
        Manager._instance.Life += _myLife;
    }
}
