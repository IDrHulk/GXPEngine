using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public abstract class Pickup : AnimationSprite
{

    protected int _amount;
    public int Amount { get => _amount; protected set => _amount = value; } 
    protected Pickup(string imageFilename, int columns, int rows) : base(imageFilename, columns, rows)
    {
        collider.isTrigger = true;
    }

}
