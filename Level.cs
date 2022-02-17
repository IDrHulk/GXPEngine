using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;
using System.IO;
public class Level : GameObject
{
    TiledLoader loader;

    Player player;

    Score score;

    HUD hud;

    PlayButton playbutton;

    public Level()
    {

    }

        public void CreateLevel(string nameLevel)
    {

        loader = new TiledLoader(nameLevel + ".tmx");
        switch (nameLevel)
        {
           
                case "Prototype2":
                loader.rootObject = this;

                //Background
                loader.addColliders = false;
                loader.LoadImageLayers();

                //Tiles
                loader.addColliders = true;
                loader.LoadTileLayers(0);   //tiles with collider

                loader.addColliders = false;
                loader.LoadTileLayers(1);

                //Objects (Player, Pickup, Enemies)
                loader.autoInstance = true;
                loader.LoadObjectGroups();

                player = this.FindObjectOfType<Player>();
                CreateHUD(player);
                SetChildIndex(player, GetChildCount());
                break;

                case "Prototype":
                loader.rootObject = this;

                
                loader.addColliders = false;
                loader.LoadImageLayers();

                loader.addColliders = true;
                loader.LoadTileLayers(0);  

                loader.addColliders = false;
                loader.LoadTileLayers(1);

                loader.autoInstance = true;
                loader.LoadObjectGroups();

                player = this.FindObjectOfType<Player>();
                CreateHUD(player);
                SetChildIndex(player, GetChildCount());

                break;

            case "Prototype3":
                loader.rootObject = this;


                loader.addColliders = false;
                loader.LoadImageLayers();

                loader.addColliders = true;
                loader.LoadTileLayers(0);

                loader.addColliders = false;
                loader.LoadTileLayers(1);

                loader.autoInstance = true;
                loader.LoadObjectGroups();

                player = this.FindObjectOfType<Player>();
                CreateHUD(player);
                SetChildIndex(player, GetChildCount());
        
                break;

            case "Winscreen":
                loader.autoInstance = true;
                loader.LoadObjectGroups();
                break;

                case "Menuscreen":
                loader.autoInstance = true;
                loader.LoadObjectGroups();
                break;

                case "HighScore":
                loader.autoInstance = true;
                loader.LoadObjectGroups();
                break;
        }
    }
   


    void Update()
    {
        if (player != null)
        {
            Scrolling(player);
            
        }
       /* if (Input.GetKeyDown(Key.A))
        {
            ((MyGame)game).LoadLevel("Menuscreen");
        }*/
    }
    public void CreateHUD(Player pTarget)
    {
        if (player == null)
            return;
        game.AddChild(new HUD(pTarget));

    }

    void Scrolling(GameObject pTarget)
    {
        this.x = (float)(-pTarget.x + game.width/6);

    }


    
}