public class Weapon
{
    private double cooldown;
    private int speed = 12;
    private bool isActive;
    private int damage = 1;
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
        Raylib.DrawCircle((int)position.X, (int)position.Y, 8, Color.BLACK);
    }
}