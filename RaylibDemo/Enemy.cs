using System;

public class Enemy : Character
{
    private static Texture2D[] spriteDirection = {
            Raylib.LoadTexture("./images/character/turtle.png"),
            Raylib.LoadTexture("./images/character/turtleL.png"),
            Raylib.LoadTexture("./images/character/turtleB.png"),
            Raylib.LoadTexture("./images/character/turtleF.png")
    };
    private Random generator = new Random();
    private int r, rx, ry;

    public Enemy()
    {
        sprite = spriteDirection[0];
        rx = generator.Next(200, 700);
        ry = generator.Next(200, 700);
        hp = 4;
        Speed = 2.5f;
        rect = new Rectangle(rx, ry, sprite.width, sprite.height);
    }
    public override void Update()
    {
        RandomAction();
        base.Update();
    }
    public override void Draw()
    {
        if (isAlive)
            base.Draw();
        Raylib.DrawText(hp + "/4", (int)rect.x, (int)rect.y, 20, Color.WHITE);
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
}
