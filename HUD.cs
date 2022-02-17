using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class HUD : EasyDraw
{
    public int sum = 0;
    Score score;

    Player player;

    Coin coin;

    public HUD(Player pTarget) : base(1366, 768, false)
    {
        coin = new Coin();
        player = pTarget;
        score = new Score();
       
    } 
    public void Update()
    {
        addScoreandCoins();
        ClearTransparent();
        TextSize(20);
        Text("Score" + sum, 20, 50);
        score.Update();
        CheckifGameStated();

    }
    public void CheckifGameStated()
    {
        if(player.Start == false)
        {
            score.score = 0;
        }       
    }

    public void addScoreandCoins()
    {
            sum = player.coins + score.ScoreValue;   
    }



}