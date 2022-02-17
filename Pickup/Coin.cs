using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Coin : Pickup
{
    public string coinType;
    Score score;
    public Coin(TiledObject obj = null) : base("Jars.png",3,1)
    {
        if (obj != null)
        {
            coinType = obj.GetStringProperty("coinType", null);
        }
        switch (coinType)
        {
            case "bronze":
                SetCycle(0,1);
                break;
            case "silver":
                SetCycle(1,1);
                break;
            case "gold":
                SetCycle(2,1);
                break;

        }

        SetScaleXY(1f, 1f);
    }

    void Update()
    {
    }



}