
public class Weapon
{
    double cooldown;
    public Weapon()
    {

    }
    public void Update(int direction, Vector2 position)
    {
        if (Raylib.IsMouseButtonDown(0) && Raylib.GetTime() - cooldown >= 0.5f)
        {
            cooldown = Raylib.GetTime();
            Draw(position);
            Console.WriteLine(direction);
        }
    }

    public void Draw(Vector2 position)
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 10, Color.BLACK);
    }
}