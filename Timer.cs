using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Timer
{
    public float timer = 0.0f;
    public  Timer()
    {

    }
    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 800)
        {

            ResetTimer();
        }
    }
    public void ResetTimer()
    {
        timer = 0;
    }
}
