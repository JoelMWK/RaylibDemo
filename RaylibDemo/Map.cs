
public class Map
{
    List<Block> blocks = new();
    private Texture2D walls = Raylib.LoadTexture("./images/tile/brick.png");
    public static List<Rectangle> mapRect = new List<Rectangle>();
    public static List<Rectangle> borderRect = new List<Rectangle>();

    private int[,] level = new int[,]{
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,3,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,4,4,4,0,2,0,2,0,1},
        {1,0,0,0,0,0,2,4,2,0,0,0,0,0,1},
        {1,3,0,2,2,0,4,4,4,0,2,2,0,3,1},
        {1,0,0,0,0,0,2,2,2,0,0,0,0,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,0,0,0,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,2,2,0,2,0,2,0,1},
        {1,0,0,0,0,0,2,0,2,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

    public void LoadMap()
    {
        for (int y = 0; y < level.GetLength(0); y++)
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                if (level[y, x] > 0)
                {
                    Block b = new Block(x, y, level[y, x]);
                    blocks.Add(b);
                }
            }
        }
    }
    public void DrawMap()
    {
        foreach (Block b in blocks)
        {
            b.Draw();
        }
    }
}
