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
                if (rect.x + rect.width >= block.rect.x) rect.x -= Speed;
                if (rect.x <= block.rect.x + block.rect.width) rect.x += Speed;
                if (rect.y <= block.rect.y) rect.y -= Speed;
                if (rect.y + rect.height >= block.rect.y + block.rect.height) rect.y += Speed;
            }
        }

        foreach (Enemy enemy in EnemySpawner.enemy)
        {
            if (enemy.ColliderRect(p.rect) && Timer() >= 1.4f)
            {
                cooldown = Raylib.GetTime();
                p.hp--;
            }
        }
    }
    public double Timer()
    {
        return Raylib.GetTime() - cooldown;
    }
}


