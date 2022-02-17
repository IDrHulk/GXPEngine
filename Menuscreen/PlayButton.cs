using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

public class PlayButton : Sprite
{
    public PlayButton(TiledObject obj) : base("Playbutton.png")
    {
        collider.isTrigger = true;
    }

    public void Update()
    {
        if(Input.GetKeyDown(Key.A))
        {
            ((MyGame)game).LoadLevel("Prototype");
           

        }

    }
}
