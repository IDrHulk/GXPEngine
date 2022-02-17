using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;
using TiledMapParser;

public class Player : AnimationSprite
{
    private int numberofJumps = 0;
    public int health = 1;
    public int coins = 0;
    public int Health { get => health; }
    public int coinValue { get => coins; }
    public int bombs = 0;
    public int lastTimeHonked = 0;

    public float pTimer = 0f;
    public float pTimerHonk = 0f;

    private float speed = 1.5f;
    private float fallingSpeed;
    private float fallingSpeedIncrement;
    private float speedX = 0;

    public bool checkJump = false;
    public bool checkifSum = false;
    public bool checkStarter = false;
    public bool Start = true;
    public bool isMirrored;
    public bool scoreimp;
    public bool SyringeEffect = false;
    public bool checkTimer;
    public bool checkTimerHonk= true;
    public bool animateHonk = false;

    HUD hud;

    Random randomGenerator;

    Coin coin;

    Timer timer;

    Honk honk;

    Firstlevel firstlevel;

    SecondLevel secondlevel;

    Thirdlevel thirdlevel;

    public Player(TiledObject obj) : base("Duck.png", 43, 1)
    {
        randomGenerator = new Random();
    }
    

    private void Update()
    {
        Animate(0.07f);
        if (checkStarter == false)
        {
            chechStarter();
        }
        HorizontalMove();
        VerticalInput();
        CheckHealth();
        if (checkTimer == true)
        {
            SyringeTimer();
        }
        ShootBullets();
        ActivateBombs();

        if (checkTimerHonk == false)
        {
            HonkTimer();
        }

        if (animateHonk == true)
        {
           SetCycle(24, 41);
            
        }
        else
        if (checkJump == true)
        {
            SetCycle(11, 19);

        }
        else
        {
            
            SetCycle(1, 11);
        }

    }
    private void HorizontalMove()
    {
        if (Start)
        {
            speedX = 3f;
            speedX += speed;
            Mirror(false, false);
            isMirrored = false;
            MoveUntilCollision(speedX, 0);
        }
        else
        {
            speedX = 0f;
            SetCycle(0, 1);
        }
    }

    private void VerticalInput()
    {
        
        fallingSpeed += 0.2f;
        fallingSpeedIncrement = Mathf.Sin(30);
        if (MoveUntilCollision(0, fallingSpeed) != null)
        {
            fallingSpeed = 0;
            numberofJumps = 0;
            checkJump = true;

        }
        else
            checkJump = false;

        if (numberofJumps >= 4)
        {
            return;
        }

        if (Input.GetKeyDown(Key.W))
        {
            numberofJumps++;
            fallingSpeed -= fallingSpeedIncrement * -10;     
        }
    }

    public void chechStarter()
    {
        if (Input.GetKey(Key.S))
        {
            checkStarter = true;
            Start = true;
        }
        else
        {
            Start = false;
            checkStarter = false;
        }
    }

    public void OnCollision(GameObject objectCollided)
    {
        if (objectCollided is Coin coin)
        {
            if (coin.coinType == "gold" || coin.coinType == "silver" || coin.coinType == "bronze")
            {
                coins += 100;
                coin.LateDestroy();
            }
        }

        if (objectCollided is Syringe syringe)
        {
            checkTimer = true;
            syringe.LateDestroy();
        }
        if (objectCollided is Barrel barrel)
        {
             barrel.LateDestroy();
             bombs += 1;
        }

    }
    
    private void SyringeTimer()
    {

        pTimer += Time.deltaTime;
        if (pTimer >= 2000)
        {
            health = 1;
            checkTimer = false;
            pTimer = 0;
            speed = 1.5f;
            
        }
        else
        {
            speed = 5f;
            health = 10;       
        }
    }

    private void HonkTimer()
    {
        pTimerHonk += Time.deltaTime;
        if (pTimerHonk >= 16000)
        {
            checkTimerHonk = true;
            pTimer = 0;
        }
    }
    public void ActivateBombs()
    {

        if (Input.GetKey(Key.S) && bombs > 0)
        {          
                Bomb bomb = new Bomb("bg_layer1.png", this, isMirrored ? -5 : 5);
                parent.AddChild(bomb);
                bomb.LateDestroy();
                bombs--;
        }
    }
    public void ShootBullets()
    {

        if (Input.GetKey(Key.D))
        {
            if (checkTimerHonk == true)
            {
                animateHonk = true;

                Honk honk = new Honk("bg_layer1.png", this, isMirrored ? -5 : 5);
                parent.AddChild(honk);
                honk.LateDestroy();
                checkTimerHonk = false;
            }
        }
        else
            animateHonk = false;
    }

    private void CheckHealth()
    {
        if (health <= 0) 
            ((MyGame)game).LoadLevel("Prototype");
  
    }

    public int GenerateRandomInt(Random rnd, int limit)
    {
        return rnd.Next(limit);
    }

    
    
}





