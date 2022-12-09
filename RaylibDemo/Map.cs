public class Map
{
    public List<Block> blocks = new List<Block>();
    public int[][] Level { get; set; }

    public void LoadMap(string filePath)
    {
        string jsonText = File.ReadAllText(filePath);
        var m = JsonSerializer.Deserialize<Map>(jsonText);

        for (int y = 0; y < m.Level.Length; y++)
        {
            for (int x = 0; x < m.Level.Length; x++)
            {
                if (m.Level[y][x] > 0)
                {
                    Block b = new Block(x, y, m.Level[y][x]);
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
