public class Block
{
    public List<Rectangle> blockList = new List<Rectangle>();
    public Texture2D[] blockTexture = new Texture2D[4];

    public int concrete = 1;
    public int brick = 2;
    public int metal = 3;
    public int leaves = 4;
    public int[] index = new int[4];

    private int width;
    private int height;
    private bool isBreakable = false;
    private bool isPassable = false;
    private bool isBroken = false;


    public void LoadTexture()
    {
        if (index[0] == concrete)
        {
            blockTexture[0] = Raylib.LoadTexture("concrete.png");
        }
        else if (index[1] == brick)
        {
            blockTexture[1] = Raylib.LoadTexture("brick.png");
            isBreakable = true;
        }
        else if (index[2] == metal)
        {
            blockTexture[2] = Raylib.LoadTexture("metal.png");
        }
        else if (index[3] == leaves)
        {
            blockTexture[3] = Raylib.LoadTexture("leaves.png");
            isPassable = true;
        }
    }
}
