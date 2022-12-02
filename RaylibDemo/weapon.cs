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
        /*if (position.X >= Raylib.GetScreenWidth() || position.X <= 0 || position.Y >= Raylib.GetScreenHeight() || position.Y <= 0)
        {
            isActive = false;
        }*/
    }
    public void Draw(Vector2 position)
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 6, Color.YELLOW);
    }
}