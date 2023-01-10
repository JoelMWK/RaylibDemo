using System;

public class Enemy : Character
{
    private Texture2D[] spriteDirection = {
            Raylib.LoadTexture("./images/character/turtle.png"),
            Raylib.LoadTexture("./images/character/turtleL.png"),
            Raylib.LoadTexture("./images/character/turtleB.png"),
            Raylib.LoadTexture("./images/character/turtleF.png")
    };
    Random generator = new Random();
    private int r;

    private Vector2[] spawnPoints =
    {
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
    };

    public Enemy()
    {
        e = this;
        hp = 4;
        Speed = 2.5f;
        sprite = Raylib.LoadTexture("./images/character/turtle.png");
        rect = new Rectangle(Raylib.GetScreenHeight() - 100, Raylib.GetScreenWidth() - 100, sprite.width, sprite.height);
    }
    public override void Update()
    {
        RandomAction();
        base.Update();
    }

    public void RandomAction()
    {
        if (Timer() >= 1.4f)
        {
            r = generator.Next(1, 5);
            cooldown = Raylib.GetTime();
        }

        if (r == 1)
        {
            rect.x += Speed;
            sprite = spriteDirection[0];
        }
        else if (r == 2)
        {
            rect.x -= Speed;
            sprite = spriteDirection[1];
        }
        else if (r == 3)
        {
            rect.y -= Speed;
            sprite = spriteDirection[2];
        }
        else if (r == 4)
        {
            rect.y += Speed;
            sprite = spriteDirection[3];
        }
    }

    public bool CheckIfAlive(Enemy e)
    {
        return e.isAlive;
    }
}
