using System;

public class Player : Character
{
    Weapon weapon = new();
    private Texture2D[] spriteDirection = {
            Raylib.LoadTexture("walter.png"),
            Raylib.LoadTexture("walterL.png"),
            Raylib.LoadTexture("walterB.png"),
            Raylib.LoadTexture("walterF.png")
    };
    private int direction = 1;
    private Vector2 position;
    private bool pressed = false;

    public Player()
    {
        sprite = Raylib.LoadTexture("walter.png");
        rect = new Rectangle(50, 50, sprite.width, sprite.height);
    }

    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !pressed)
        {
            pressed = true;
            rect.x += Speed;
            sprite = spriteDirection[0];
            direction = 1;
            position = new Vector2(rect.x + sprite.width + 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !pressed)
        {
            pressed = true;
            rect.x -= Speed;
            sprite = spriteDirection[1];
            direction = -1;
            position = new Vector2(rect.x - 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !pressed)
        {
            pressed = true;
            rect.y -= Speed;
            sprite = spriteDirection[2];
            direction = 2;
            position = new Vector2(rect.x + sprite.width / 2, rect.y - 10);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && !pressed)
        {
            pressed = true;
            rect.y += Speed;
            sprite = spriteDirection[3];
            direction = -2;
            position = new Vector2(rect.x + sprite.width / 2, rect.y + sprite.height + 10);
        }

        pressed = false;
        weapon.Update(direction, position);

        base.Update();
    }
    public void UpdateBullet(int speed)
    {
        if (direction == 1)
        {
            position.X += speed;
        }
        else if (direction == -1)
        {
            position.X -= speed;
        }
        else if (direction == 2)
        {
            position.Y -= speed;
        }
        else if (direction == -2)
        {
            position.Y += speed;
        }
    }
}
