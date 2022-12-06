
public class Map
{
    Block block = new Block();
    private Texture2D walls = Raylib.LoadTexture("brick.png");
    public static List<Rectangle> mapRect = new List<Rectangle>();
    public static List<Rectangle> borderRect = new List<Rectangle>();
    private int[,] level = new int[,]{
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,0,0,0,0,2,0,2,0,1},
        {1,0,0,0,0,0,2,0,2,0,0,0,0,0,1},
        {1,2,0,2,2,0,0,0,0,0,2,2,0,2,1},
        {1,0,0,0,0,0,2,2,2,0,0,0,0,0,1},
        {1,0,2,0,2,0,2,0,2,0,2,0,2,0,1},
        {1,0,2,0,2,0,0,0,0,0,2,0,2,0,1},
        {1,0,2,0,2,0,2,2,2,0,2,0,2,0,1},
        {1,0,0,0,0,0,2,0,2,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };
    private int y;
    private int x;

    public void LoadMap()
    {
        for (y = 0; y < level.GetLength(0); y++)
        {
            for (x = 0; x < level.GetLength(1); x++)
            {
                if (level[y, x] == 1)
                {
                    block.index[0] = 1;
                    block.blockList.Add(new Rectangle(x * 62, y * 62, 62, 62));
                    //borderRect.Add(new Rectangle(x * 62, y * 62, 62, 62));
                }
                else if (level[y, x] == 2)
                {
                    block.index[1] = 2;
                    block.blockList.Add(new Rectangle(x * 62, y * 62, 62, 62));
                    //mapRect.Add(new Rectangle(x * 62, y * 62, 62, 62));
                }
            }
        }
        block.LoadTexture();
        for (int i = 0; i < block.index.Count(); i++)
        {
            Console.WriteLine(block.index[i]);
        }
    }
    public void DrawMap()
    {
        for (int i = 0; i < block.blockList.Count(); i++)
        {
            Rectangle box = block.blockList[i];
            if (block.index[0] == 1)
                Raylib.DrawTexture(block.blockTexture[0], (int)box.x, (int)box.y, Color.WHITE);
            if (block.index[1] == 2)
                Raylib.DrawTexture(block.blockTexture[1], (int)box.x, (int)box.y, Color.WHITE);
        }
    }
}
