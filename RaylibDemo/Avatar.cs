using System;

public class Avatar
{
    private Rectangle rect;
    private Texture2D sprite;
    private Texture2D[] spriteDirection = {
            Raylib.LoadTexture("walter.png"),
            Raylib.LoadTexture("walterL.png"),
            Raylib.LoadTexture("walterB.png"),
            Raylib.LoadTexture("walterF.png")
    };
    private float speed = 3.5f;
    private int hp = 10;
    private double damageImmune = 0;

    public Avatar()
    {
        sprite = Raylib.LoadTexture("walter.png");
        rect = new Rectangle(0, 0, sprite.width, sprite.height);
    }

    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            rect.x += speed;
            sprite = spriteDirection[0];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            rect.x -= speed;
            sprite = spriteDirection[1];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            rect.y -= speed;
            sprite = spriteDirection[2];
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            rect.y += speed;
            sprite = spriteDirection[3];
        }

        if (rect.x <= 0)
        {
            rect.x = 0;
        }
        if (rect.x + sprite.width >= Raylib.GetScreenWidth())
        {
            rect.x = Raylib.GetScreenWidth() - sprite.width;
        }
        if (rect.y <= 0)
        {
            rect.y = 0;
        }
        if (rect.y + sprite.height >= Raylib.GetScreenHeight())
        {
            rect.y = Raylib.GetScreenHeight() - sprite.height;
        }
    }

    public void Draw()
    {
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public void Collision()
    {
        if (Raylib.CheckCollisionRecs(rect, Enemy.rect))
        {
            if (Raylib.GetTime() - damageImmune >= 1f)
                hp--;
        }
    }
}
