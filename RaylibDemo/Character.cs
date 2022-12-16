public class Character
{
    public Rectangle rect;
    protected Texture2D sprite;
    protected double cooldown;
    public float Speed { get; set; } = 3.5f;
    public int hp;
    public bool isAlive
    {
        get
        {
            return hp > 0;
        }
        private set { }
    }

    public static Player p;
    public static Enemy e;

    public void Draw()
    {
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }
    public bool ColliderRect(Rectangle otherRect)
    {
        return Raylib.CheckCollisionRecs(rect, otherRect);
    }
    public bool ColliderVector(Vector2 otherVector, float radius)
    {
        return Raylib.CheckCollisionCircleRec(otherVector, radius, rect);
    }
    public virtual void Update()
    {
        // if (rect.x <= 0)
        // {
        //     rect.x = 0;
        // }
        // if (rect.x + sprite.width >= Raylib.GetScreenWidth())
        // {
        //     rect.x = Raylib.GetScreenWidth() - sprite.width;
        // }
        // if (rect.y <= 0)
        // {
        //     rect.y = 0;
        // }
        // if (rect.y + sprite.height >= Raylib.GetScreenHeight())
        // {
        //     rect.y = Raylib.GetScreenHeight() - sprite.height;
        // }
    }
    public double Timer()
    {
        return Raylib.GetTime() - cooldown;
    }
    public void MapCollision()
    {
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {
                if (rect.x >= block.rect.x) rect.x += Speed;
                else if (rect.x <= block.rect.x) rect.x -= Speed;
            }
        }
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {
                if (rect.y >= block.rect.y) rect.y += Speed;
                else if (rect.y <= block.rect.y) rect.y -= Speed;
            }
        }

    }
}


