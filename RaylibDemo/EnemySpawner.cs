public class EnemySpawner
{
    public static List<Enemy> enemy = new List<Enemy>();
    double cooldown;

    public void Spawn()
    {
        Enemy e = new();

        if (enemy.Count() < 10)
        {
            enemy.Add(e);
        }
    }
    public void Update()
    {
        if (Raylib.GetTime() - cooldown >= 5f)
        {
            cooldown = Raylib.GetTime();
            Spawn();
        }
        foreach (Enemy e in enemy)
        {
            e.Update();
            if (!e.isAlive)
                Player.p.score++;
        }
        enemy.RemoveAll(e => !e.isAlive);
    }
    public void Draw()
    {
        foreach (Enemy e in enemy)
        {
            e.Draw();
        }
    }
}
