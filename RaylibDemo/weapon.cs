
public class Weapon
{
    private double cooldown;
    private int speed = 6;
    private bool isActive;
    public Weapon()
    {

    }
    public void Update(int direction, Vector2 position)
    {
        if (Raylib.IsMouseButtonDown(0) && Raylib.GetTime() - cooldown >= 0.5f)
        {
            cooldown = Raylib.GetTime();
            isActive = true;
        }
        if (isActive)
        {
            Draw(position);
        }
    }

    public void Draw(Vector2 position)
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 10, Color.BLACK);
    }
}