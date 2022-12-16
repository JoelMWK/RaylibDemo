global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 900, "Breaking Bad");
Raylib.SetTargetFPS(60);

Player walter = new Player();
Enemy tortuga = new Enemy();
Map map = new Map();
int i = 1;

map.LoadMap("./stages/stage1.json");

while (!Raylib.WindowShouldClose())
{
    //Logik
    walter.Update();
    tortuga.Update();
    walter.MapCollision();
    tortuga.MapCollision();
    map.BlockCheck();

    //Temp code
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_PAGE_DOWN))
    {
        i++;
        Block.blockList.Clear();
        map.blocks.Clear();
        map.LoadMap($"./stages/stage{i}.json");
    }
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_PAGE_UP))
    {
        i--;
        Block.blockList.Clear();
        map.blocks.Clear();
        map.LoadMap($"./stages/stage{i}.json");
    }
    //

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    walter.DrawBullet();
    walter.Draw();
    tortuga.Draw();
    map.DrawMap();

    Raylib.EndDrawing();
}