using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;
using TiledMapParser;

public class MyGame : Game
{
    Level level;
    HUD hud;
    
    public MyGame() : base(1366, 768, false)
    {
        LoadLevel("Menuscreen");
      
       
    }
    static void Main()
    {
        new MyGame().Start();
    }
    public void LoadLevel(string levelFilename)
    {
        DestroyLevel();
        level = new Level();
        AddChild(level);
        level.CreateLevel(levelFilename);


    }
    void DestroyLevel()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject c in children)
        {
            c.Destroy();
        }
    }
    public void Update()
    {
        if (Input.GetKey(Key.F))
            Console.WriteLine(currentFps);
    }
    

}



