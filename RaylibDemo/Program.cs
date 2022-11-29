﻿global using Raylib_cs;
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
    // weapon.Update();


    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    walter.Draw();
    tortuga.Draw();


    Raylib.EndDrawing();
}