using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;
public class SecondLevel : Sprite
{
    public bool won = false;
    public int rand;
    public bool checkrand = false;
    Random randomGenerator;
    Level level;
    public SecondLevel(TiledObject obj) : base("empty.png")
    {
        collider.isTrigger = true;
    }


    public void Update()
    {
        if (won == true)
        {
            ((MyGame)game).LoadLevel("Prototype3");
        }

    }

    public void OnCollision(GameObject obj)
    {
        if (obj is Player player)
        {
            won = true;
        }
    }

}
