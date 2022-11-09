
public class weapon
{
    private int bulletCap = 4;
    private Rectangle bullet;
    private Vector2 pos;
    private Vector2 origin;
    private double speed;
    private bool active = false;

    private double mouseX;
    private double mouseY;

    public weapon()
    {
        origin = new Vector2(100, 100);
        bullet = new Rectangle(pos.X, pos.Y, 15, 15);
        speed = 4;
    }

    public void Update()
    {
        if (active)
        {
            Shoot();
            Draw();
        }
        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
        {
            active = true;
        }
        if (pos.X > Raylib.GetScreenWidth() || pos.Y > Raylib.GetScreenHeight())
        {
            active = false;
            pos = origin;
        }
    }

    public void Draw()
    {
        //Raylib.DrawRectangle((int)pos.X, (int)pos.Y, (int)bullet.width, (int)bullet.height, Color.BLACK);
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, 10, Color.BLACK);
        Raylib.DrawLine((int)origin.X, (int)origin.Y, (int)mouseX, (int)mouseY, Color.BLACK);
    }
    public void Shoot()
    {
        mouseX = Raylib.GetMousePosition().X;
        mouseY = Raylib.GetMousePosition().Y;

        Vector2 mousePosition = new Vector2((float)mouseX, (float)mouseY);

        for (int i = 0; i < bulletCap; i++)
        {
        }
        double angle = Math.Atan2(mousePosition.Y - origin.Y, mousePosition.X - origin.X);
        double xVel = speed * Math.Cos(angle);
        double yVel = speed * Math.Sin(angle);

        pos.X += (float)xVel;
        pos.Y += (float)yVel;

    }
}
