using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
using System.Drawing.Text;
public class HighScore: Sprite
{
    Score score;
    public HighScore(TiledObject obj) : base("bg_layer1.png")
    {
        collider.isTrigger = true;
        score = new Score();
    }

    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            ((MyGame)game).LoadLevel("HighScore");
        }*/
    }
} 
