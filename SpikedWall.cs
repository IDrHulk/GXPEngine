using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class SpikedWall : Sprite
{
    Honk honk;
    public SpikedWall(TiledObject obj) : base("Wire.png")
    {
        collider.isTrigger = true;
    }   
    
    public void OnCollision(GameObject obj)
    {
        if(obj is Player player)
        {
            LateDestroy();
            player.health -=1;
        }
        if(obj is Honk honk)
        {
            honk.LateDestroy();
        }
    }
}





