global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(800, 600, "Breaking Bad");
Raylib.SetTargetFPS(60);

Texture2D bg = Raylib.LoadTexture("wallpaper.png");
Avatar walter = new Avatar();
//Enemy tortuga = new Enemy();
Weapon weapon = new Weapon();


while (!Raylib.WindowShouldClose())
{
    //Logik
    walter.Update();
    //tortuga.Update();
    weapon.Update();

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    //Raylib.DrawTexture(bg, 0, 0, Color.WHITE);

    walter.Draw();
    //tortuga.Draw();


    Raylib.EndDrawing();
}