using System;

public class Player : Character
{
    private List<Bullets> bullets = new List<Bullets>(); //lista av bullets klassen
    private Texture2D[] spriteDirection = { //Textur array av player
            Raylib.LoadTexture("./images/character/walter.png"),
            Raylib.LoadTexture("./images/character/walterL.png"),
            Raylib.LoadTexture("./images/character/walterB.png"),
            Raylib.LoadTexture("./images/character/walterF.png")
    };
    private int direction = 1;
    private Vector2 origin;
    private bool pressed = false;
    public int score;
    public Player() //Konstructor för player
    {
        p = this; //visar att p = player
        hp = 3;
        sprite = Raylib.LoadTexture("./images/character/walter.png");
        rect = new Rectangle(60, 60, sprite.width, sprite.height);
        origin = new Vector2(rect.x + sprite.width + 10, rect.y + sprite.height / 2);
    }

    public override void Update() //Update funktion som överskriver Character update
    {
        if (hp <= 0) //kollar om hp är 0
        {
            Environment.Exit(0); // stänger applicationen
        }
        Raylib.DrawText("Health: " + hp, 60, 80, 20, Color.WHITE);
        Raylib.DrawText("Score: " + score, 60, 60, 20, Color.WHITE);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && Raylib.GetTime() - cooldown >= 1f) //Kollar om man trycker space och det har gått 0.6 sekunder
        {
            cooldown = Raylib.GetTime(); //cooldown för att man inte ska kunna spamma
            Shoot();
        }
        UpdateBullet();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !pressed) //Höger movement 
        {
            pressed = true;
            rect.x += Speed;
            sprite = spriteDirection[0];
            direction = 1;
            origin = new Vector2(rect.x + sprite.width + 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !pressed) //Vänster movement
        {
            pressed = true;
            rect.x -= Speed;
            sprite = spriteDirection[1];
            direction = -1;
            origin = new Vector2(rect.x - 10, rect.y + sprite.height / 2);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !pressed) //Upp movement
        {
            pressed = true;
            rect.y -= Speed;
            sprite = spriteDirection[2];
            direction = -2;
            origin = new Vector2(rect.x + sprite.width / 2, rect.y - 10);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && !pressed) //Nedåt movement
        {
            pressed = true;
            rect.y += Speed;
            sprite = spriteDirection[3];
            direction = 2;
            origin = new Vector2(rect.x + sprite.width / 2, rect.y + sprite.height + 10);
        }
        pressed = false; //tar hand om man håller ned en knapp eller inte för att man bara ska kunna gå åt ett håll.

        base.Update(); //Kallar character update i player update
    }

    //----------Bullets-----------//
    private void Shoot()
    {
        Bullets b = new(); //Skapar en ny bullet instance

        b.Shoot(origin, direction); //Definerar vart på skärmen bulleten ska skjutas ifrån

        if (bullets.Count() < b.magazineSize) // kollar om det finns mer intanser i bullet listan än bulletcap (magazineSize).
        {
            bullets.Add(b); //Lägger till intansen i listan bullets.
        }
    }
    private void UpdateBullet()
    {
        foreach (Bullets b in bullets) //Tar in bullets listan och definerar alla intanser som b
        {
            b.Update(); //Kallar update funktioner för alla b
        }
        bullets.RemoveAll(b => !b.isActive); //Alla b instanser som är inte aktiv blir borttagna från bullets listan
    }
    public void DrawBullet()
    {
        foreach (Bullets b in bullets)
        {
            b.Draw(); //Kallar Draw funktion för alla b
        }
    }
}
