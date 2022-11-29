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

    public Player()
    {
        sprite = Raylib.LoadTexture("walter.png");
        rect = new Rectangle(0, 0, sprite.width, sprite.height);
    }

    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            rect.x += Speed;
            sprite = spriteDirection[0];
            weapon.Update(1, new Vector2(rect.x + sprite.width, rect.y + sprite.height / 2 + 10));
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            rect.x -= Speed;
            sprite = spriteDirection[1];
            weapon.Update(-1, new Vector2(rect.x - 10, rect.y + sprite.height / 2));
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            rect.y -= Speed;
            sprite = spriteDirection[2];
            weapon.Update(2, new Vector2(rect.x + sprite.width / 2, rect.y - 10));
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            rect.y += Speed;
            sprite = spriteDirection[3];
            weapon.Update(-2, new Vector2(rect.x + sprite.width / 2, rect.y + sprite.height + 10));
        }

        base.Update();
    }
}
