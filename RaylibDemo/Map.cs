public class Map
{
    private Texture2D walls = Raylib.LoadTexture("brick.png");
    public static List<Rectangle> mapRect = new List<Rectangle>();
    private int[,] level = new int[,]{
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,1},
        {1,0,2,2,0,2,2,2,0,0,2,2,2,0,0,1},
        {1,0,0,2,0,0,0,0,0,0,0,0,2,0,0,1},
        {1,0,0,2,2,0,0,0,0,0,0,0,0,0,0,1},
        {1,2,0,0,0,0,0,0,0,0,0,0,0,2,2,1},
        {1,2,2,0,0,2,2,2,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,2,0,0,0,0,2,0,0,0,0,1},
        {1,0,0,0,0,2,0,0,0,0,2,0,0,0,0,1},
        {1,0,0,0,0,2,0,0,2,2,2,0,0,0,0,1},
        {1,0,2,0,0,2,0,0,0,0,0,0,0,2,0,1},
        {1,0,2,0,2,0,0,0,0,0,0,0,0,2,0,1},
        {1,0,2,0,2,2,2,2,2,0,0,0,0,2,2,1},
        {1,0,2,0,0,0,0,0,2,2,2,0,0,0,0,1},
        {1,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
    };

    public void LoadMap()
    {

        for (int y = 0; y < level.GetLength(0); y++)
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                if (level[y, x] == 1)
                {
                    mapRect.Add(new Rectangle(x * 50, y * 50, 50, 50));
                }
                else if (level[y, x] == 2)
                {
                    mapRect.Add(new Rectangle(x * 50, y * 50, 50, 50));
                }
            }
        }
    }

    public void DrawMap()
    {
        foreach (Rectangle box in mapRect)
        {
            //Raylib.DrawRectangleRec(box, Color.GRAY);
            Raylib.DrawTexture(walls, (int)box.x, (int)box.y, Color.WHITE);
        }
    }

}
