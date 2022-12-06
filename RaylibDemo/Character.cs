public class Character
{
    public Rectangle rect;
    protected Texture2D sprite;
    protected double cooldown;
    protected float Speed { get; set; } = 3.5f;
    protected int Hp { get; set; } = 4;

    public void Draw()
    {
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }
    public virtual void Update()
    {
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
    public void MapCollision()
    {
        foreach (Rectangle box in Map.mapRect)
        {
            bool collisionX = Raylib.CheckCollisionRecs(rect, box);
            if (collisionX)
            {
                if (rect.x >= box.x) rect.x += Speed;
                else if (rect.x <= box.x) rect.x -= Speed;
            }
        }
        foreach (Rectangle box in Map.mapRect)
        {
            bool collisionY = Raylib.CheckCollisionRecs(rect, box);
            if (collisionY)
            {
                if (rect.y >= box.y) rect.y += Speed;
                else if (rect.y <= box.y) rect.y -= Speed;
            }
        }
    }
}


