using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Syringe : Sprite
{
  public Syringe(TiledObject obj) : base("Syringe.png")
    {
        collider.isTrigger = true;
    }

}

