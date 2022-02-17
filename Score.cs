using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Score : GameObject
{
    public int score = 0;

    public int ScoreValue { get => score; }
    Player player;
    Timer timer;
    public Score()
    {
        timer = new Timer();
    }
    public void Update()
    {
        timer.timer += Time.deltaTime;
        if (timer.timer >= 800)
        {
            score += 10;
            timer.ResetTimer();
        }

    }

}
