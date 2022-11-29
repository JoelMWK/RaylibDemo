using System;

public class Enemy : Character
{
    private Texture2D[] spriteDirection = {
            Raylib.LoadTexture("turtle.png"),
            Raylib.LoadTexture("turtleL.png"),
            Raylib.LoadTexture("turtleB.png"),
            Raylib.LoadTexture("turtleF.png")
    };

    public Enemy()
    {
        Speed = 2.5f;
        sprite = Raylib.LoadTexture("turtle.png");
        rect = new Rectangle(Raylib.GetScreenHeight(), Raylib.GetScreenWidth(), sprite.width, sprite.height);
    }
    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            rect.x += Speed;
            sprite = spriteDirection[0];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            rect.x -= Speed;
            sprite = spriteDirection[1];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            rect.y -= Speed;
            sprite = spriteDirection[2];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            rect.y += Speed;
            sprite = spriteDirection[3];
        }

        base.Update();
    }
}
