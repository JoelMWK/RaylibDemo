public class EnemySpawner
{
    public static List<Enemy> enemy = new List<Enemy>();

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
        if (Raylib.IsMouseButtonPressed(0))
        {
            Spawn();
        }
        foreach (Enemy e in enemy)
        {
            e.Update();
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
