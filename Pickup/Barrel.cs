using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Barrel : Sprite
{
   
        public Barrel(TiledObject obj) : base("Barrel.png")
        {
            collider.isTrigger = true;
        }

   
}