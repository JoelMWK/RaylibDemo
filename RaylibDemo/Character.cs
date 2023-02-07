public class Character
{
    public Rectangle rect;
    protected Texture2D sprite;
    protected double cooldown = 0;
    public float Speed { get; set; } = 3.5f;
    public int hp;
    public bool isAlive
    {
        get
        {
            return hp > 0; //get, set. Som kollar om hp är större än noll. Om Hp är mindre så returneras isAlive = false.
        }
        private set { }
    }

    public static Player p;
    public static Enemy e;

    public virtual void Draw()
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
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect) && !block.IsBroken && !block.IsPassable)
            {
                if (rect.x >= block.rect.x) rect.x += Speed;
                if (rect.x <= block.rect.x) rect.x -= Speed;
            }
        }
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect) && !block.IsBroken && !block.IsPassable)
            {
                if (rect.y <= block.rect.y) rect.y -= Speed;
                if (rect.y >= block.rect.y) rect.y += Speed;
            }
        }
        foreach (Enemy enemy in EnemySpawner.enemy)
        {
            if (enemy.ColliderRect(p.rect) && Raylib.GetTime() - cooldown >= 1.5f)
            {
                cooldown = Raylib.GetTime();
                p.hp--;
            }
        }
    }
}


