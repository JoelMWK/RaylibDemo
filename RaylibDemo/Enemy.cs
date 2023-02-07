using System;

public class Enemy : Character
{
    private static Texture2D[] spriteDirection = { //Textur array för enemy
            Raylib.LoadTexture("./images/character/turtle.png"),
            Raylib.LoadTexture("./images/character/turtleL.png"),
            Raylib.LoadTexture("./images/character/turtleB.png"),
            Raylib.LoadTexture("./images/character/turtleF.png")
    };
    private Random generator = new Random(); //Random generator
    private int r, rx, ry;

    public Enemy() //Enemy konstructor
    {
        sprite = spriteDirection[0];
        rx = generator.Next(200, 700); //Random x position mellan 200-700
        ry = generator.Next(200, 700); //Random y position mellan 200-700
        hp = 4;
        Speed = 2.5f;
        rect = new Rectangle(rx, ry, sprite.width, sprite.height);
    }
    public override void Update() //Update som översrkiver character update.
    {
        RandomAction();
        base.Update(); //Kallar character update
    }
    public override void Draw() //Draw som överskriver character draw
    {
        if (isAlive) //Om isAlive är true så kallas character update
            base.Draw();
        Raylib.DrawText(hp + "/4", (int)rect.x, (int)rect.y, 20, Color.WHITE);
    }

    public void RandomAction()
    {
        if (Raylib.GetTime() - cooldown >= 2f) //Varje 2 sekunder så spelas koden upp igen
        {
            r = generator.Next(1, 5); //Slumpar mellan 0-5
            cooldown = Raylib.GetTime();
        }
        //Med den slumpade variablen så körs en av kodblocken, som flyttar enemy åt något håll
        if (r == 1)
        {
            rect.x += Speed;
            sprite = spriteDirection[0];
        }
        else if (r == 2)
        {
            rect.x -= Speed;
            sprite = spriteDirection[1];
        }
        else if (r == 3)
        {
            rect.y -= Speed;
            sprite = spriteDirection[2];
        }
        else if (r == 4)
        {
            rect.y += Speed;
            sprite = spriteDirection[3];
        }
    }
}
