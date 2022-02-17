using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Honk : Sprite
{
    public Sprite owner;
    public Honk(string imageFile, Sprite pOwner, float speedX) : base(imageFile) 
    {
            owner = pOwner;
            SetXY(pOwner.x + 50, pOwner.y - 75);
            SetOrigin(pOwner.width, pOwner.height);
            SetScaleXY(0.15f, 0.1f);       
    }
    public void OnCollision(GameObject objectCollided)
    {
        if (objectCollided is SpikedWall spikedWall)
        {
            spikedWall.LateDestroy();
        }

    }

}
