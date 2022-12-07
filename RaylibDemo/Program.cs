global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(900, 900, "Breaking Bad");
Raylib.SetTargetFPS(60);

Player walter = new Player();
Enemy tortuga = new Enemy();
Map map = new Map();

map.LoadMap();

while (!Raylib.WindowShouldClose())
{
    //Logik
    walter.Update();
    tortuga.Update();
    walter.MapCollision();
    tortuga.MapCollision();

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    walter.DrawBullet();
    walter.Draw();
    tortuga.Draw();
    map.DrawMap();

    Raylib.EndDrawing();
}