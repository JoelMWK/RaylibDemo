using System;

public class Player : Character
{
    private List<Bullets> bullets = new List<Bullets>();
    private Texture2D[] spriteDirection = {
            Raylib.LoadTexture("walter.png"),
            Raylib.LoadTexture("walterL.png"),
            Raylib.LoadTexture("walterB.png"),
            Raylib.LoadTexture("walterF.png")
    };
    private int direction = 1;
    private Vector2 origin;
    private bool pressed = false;

    public Player()
    {
        sprite = Raylib.LoadTexture("walter.png");
        rect = new Rectangle(50, 50, sprite.width, sprite.height);
        origin = new Vector2(rect.x + sprite.width + 10, rect.y + sprite.height / 2);
    }

    public override void Update()
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && Raylib.GetTime() - cooldown >= 1.2f)
        {
            cooldown = Raylib.GetTime();
            Shoot();
        }
        UpdateBullet();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !pressed)
        {
            pressed = true;
            rect.x += Speed;
            sprite = spriteDirection[0];
            direction = 1;
            origin = new Vector2(rect.x + sprite.width + 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !pressed)
        {
            pressed = true;
            rect.x -= Speed;
            sprite = spriteDirection[1];
            direction = -1;
            origin = new Vector2(rect.x - 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !pressed)
        {
            pressed = true;
            rect.y -= Speed;
            sprite = spriteDirection[2];
            direction = -2;
            origin = new Vector2(rect.x + sprite.width / 2, rect.y - 10);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && !pressed)
        {
            pressed = true;
            rect.y += Speed;
            sprite = spriteDirection[3];
            direction = 2;
            origin = new Vector2(rect.x + sprite.width / 2, rect.y + sprite.height + 10);
        }
        pressed = false;

        base.Update();
    }

    //----------Bullets-----------//
    public void Shoot()
    {
        Bullets b = new();

        b.Shoot(origin, direction);

        if (bullets.Count() < b.magazineSize)
        {
            bullets.Add(b);
        }
    }
    public void UpdateBullet()
    {
        foreach (Bullets b in bullets)
        {
            b.Update();
        }
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].isActive)
            {
                bullets.RemoveAt(i);
            }
        }
    }
    public void DrawBullet()
    {
        foreach (Bullets b in bullets)
        {
            b.Draw();
        }
    }
}
