global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 900, "Breaking Bad");
Raylib.SetTargetFPS(60);

Player walter = new Player();
Enemy tortuga = new Enemy();
Map map = new Map();

map.LoadMap("./stages/stage7.json");

while (!Raylib.WindowShouldClose())
{

    //Logik
    walter.Update();
    tortuga.Update();
    walter.MapCollision();
    tortuga.MapCollision();

    if (Raylib.IsMouseButtonDown(0))
    {
        map.LoadMap("./stages/stage1.json");
    }

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    walter.DrawBullet();
    walter.Draw();
    tortuga.Draw();
    map.DrawMap();

    Raylib.EndDrawing();
}