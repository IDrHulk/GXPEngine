using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;
public class Firstlevel : Sprite
{
    public bool won = false;
    public int rand;
    public int health1 = 1;
    public bool checkrand = false;
    Random randomGenerator;
    Level level;

    public Firstlevel(TiledObject obj) : base("empty.png")
    {
        collider.isTrigger = true;
        randomGenerator = new Random();
    }


   public void Update()
    {
        if (won == true)
        {
            ((MyGame)game).LoadLevel("Prototype2");
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
