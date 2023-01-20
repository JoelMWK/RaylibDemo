public class Bullets
{
    private int speed = 12;
    private int playerDirection;
    public Vector2 position;
    public int magazineSize = 1;
    public bool isActive;
    private double cooldown;
    public Bullets()
    {
        isActive = false;
    }
    public void Update()
    {
        Collision();

        if (playerDirection == 1 || playerDirection == -1)
            position.X += playerDirection * speed;
        else if (playerDirection == 2 || playerDirection == -2)
            position.Y += playerDirection / 2 * speed;

        if (position.X >= Raylib.GetScreenWidth() || position.X <= 0 || position.Y >= Raylib.GetScreenHeight() || position.Y <= 0)
            isActive = false;
    }
    public void Shoot(Vector2 origin, int direction)
    {
        playerDirection = direction;
        position = new Vector2(origin.X, origin.Y);
        isActive = true;
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 6, Color.YELLOW);
    }
    public void Collision()
    {
        foreach (Enemy enemy in EnemySpawner.enemy)
        {
            if (enemy.ColliderVector(position, 6) && Raylib.GetTime() - cooldown >= 1f)
            {
                cooldown = Raylib.GetTime();
                enemy.hp--;
                isActive = false;
            }
        }
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionCircle(position, 6) && !block.IsBroken && !block.IsPassable)
            {
                isActive = false;
                if (block.IsBreakable)
                    block.blockHp--;
            }
        }
    }
}
