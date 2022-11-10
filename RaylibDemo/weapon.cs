
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
    private double lifetime;
    private double angle;
    private Vector2 mousePosition;
    private double xVel;
    private double yVel;

    private bool mouseLock = false;

    public weapon()
    {
        //origin = new Vector2(100, 100);
        bullet = new Rectangle(pos.X, pos.Y, 15, 15);
        speed = 10;
    }
    public void Update()
    {
        Console.WriteLine(origin);
        origin.X = Avatar.rect.x + Avatar.rect.width / 2;
        origin.Y = Avatar.rect.y + Avatar.rect.height / 2;

        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT) && Raylib.GetTime() - lifetime >= 0.8f)
        {
            active = true;
            lifetime = Raylib.GetTime();
        }

        if (active)
        {
            Draw();
            Shoot();
            mouseLock = true;
        }
        if (pos.X > Raylib.GetScreenWidth() || pos.Y > Raylib.GetScreenHeight())
        {
            active = false;
            pos = origin;
            mouseLock = false;
        }
        else if (pos.X < 0 || pos.Y < 0)
        {
            active = false;
            pos = origin;
            mouseLock = false;
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

        mousePosition = new Vector2((float)mouseX, (float)mouseY);
        xVel = speed * Math.Cos(angle);
        yVel = speed * Math.Sin(angle);
        if (!mouseLock)
        {
            angle = Math.Atan2(mousePosition.Y - origin.Y, mousePosition.X - origin.X);
        }
        pos.X += (float)xVel;
        pos.Y += (float)yVel;
    }
}
