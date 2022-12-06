global using Raylib_cs;
global using System.Numerics;
using System.Text.Json;

Raylib.InitWindow(800, 800, "Breaking Bad");
Raylib.SetTargetFPS(60);

Player walter = new Player();
Enemy tortuga = new Enemy();
Map map = new Map();

map.LoadMap();

Camera2D camera2D = new Camera2D()
{
    target = new Vector2(),
    offset = new Vector2(0, 0),
    rotation = 0.0f,
    zoom = 0.86f
};

while (!Raylib.WindowShouldClose())
{
    //camera2D.target = new Vector2(walter.rect.x + walter.rect.width / 2, walter.rect.y + walter.rect.height / 2);
    //Logik
    walter.Update();
    tortuga.Update();
    walter.MapCollision();
    tortuga.MapCollision();

    //Grafik
    Raylib.BeginDrawing();
    Raylib.BeginMode2D(camera2D);
    Raylib.ClearBackground(Color.BLACK);

    walter.DrawBullet();
    walter.Draw();
    tortuga.Draw();
    map.DrawMap();

    Raylib.EndMode2D();
    Raylib.EndDrawing();
}