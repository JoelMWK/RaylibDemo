global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(800, 600, "Breaking Bad");
Raylib.SetTargetFPS(60);

Player walter = new Player();
Enemy tortuga = new Enemy();
Weapon weapon = new Weapon();

while (!Raylib.WindowShouldClose())
{
    //Logik
    walter.Update();
    tortuga.Update();


    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    //Temp walls
    Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), 20, Color.BLACK);
    Raylib.DrawRectangle(0, 0, 20, Raylib.GetScreenHeight(), Color.BLACK);
    Raylib.DrawRectangle(Raylib.GetScreenWidth() - 20, 0, 20, Raylib.GetScreenHeight(), Color.BLACK);
    Raylib.DrawRectangle(0, Raylib.GetScreenHeight() - 20, Raylib.GetScreenWidth(), 20, Color.BLACK);

    walter.Draw();
    tortuga.Draw();

    Raylib.EndDrawing();
}