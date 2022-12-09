public class Block
{
    public static Texture2D[] textures = {
        Raylib.LoadTexture("./images/tile/concrete.png"),
        Raylib.LoadTexture("./images/tile/brick.png"),
        Raylib.LoadTexture("./images/tile/metal.png"),
        Raylib.LoadTexture("./images/tile/leaves.png"),
        Raylib.LoadTexture("./images/tile/jr.png")
    };
    public static int Type { get; set; }
    public bool IsBreakable { get; set; }
    public bool IsPassable { get; set; }
    private Texture2D blockTexture;
    protected Rectangle rect;
    private float blockSize = 60;

    public Block(int x, int y, int type)
    {
        Type = type;
        rect = new Rectangle(x * blockSize, y * blockSize, blockSize, blockSize);
        blockTexture = textures[Type - 1]; //Type är 1-4 då inget ska ritas på 0. textures[] är 0-1-2-3.
    }

    public void Draw()
    {
        Raylib.DrawTexture(blockTexture, (int)rect.x, (int)rect.y, Color.WHITE);
    }
}
