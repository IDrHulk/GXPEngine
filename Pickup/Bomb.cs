using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

public class Bomb : Sprite
{
    public Sprite owner;
    public Bomb(string imageFile, Sprite pOwner, float speedX) : base(imageFile)
    {
        owner = pOwner;
        SetXY(pOwner.x - 100, pOwner.y - 500);
        SetOrigin(pOwner.width, pOwner.height);
        SetScaleXY(0.5f, 0.5f);
    }

    public void OnCollision(GameObject objectCollided)
    {
        if (objectCollided is SpikedWall spikedWall)
        {
            spikedWall.LateDestroy();
        }

    }
}

