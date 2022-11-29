public class Character
{
    protected Rectangle rect;
    protected Texture2D sprite;
    protected float Speed { get; set; } = 3.5f;
    protected int Hp { get; set; } = 4;

    public void Draw()
    {
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }
    public virtual void Update()
    {
        if (rect.x <= 0)
        {
            rect.x = 0;
        }
        if (rect.x + sprite.width >= Raylib.GetScreenWidth())
        {
            rect.x = Raylib.GetScreenWidth() - sprite.width;
        }
        if (rect.y <= 0)
        {
            rect.y = 0;
        }
        if (rect.y + sprite.height >= Raylib.GetScreenHeight())
        {
            rect.y = Raylib.GetScreenHeight() - sprite.height;
        }
    }
}


