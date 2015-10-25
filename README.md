# CFGameLibrary
A simple game library for C# which speeds up the process of making games by allowing developers to focus more on the logic of the game rather than the pipeline.

# How To Use
## INSTALLATION
Simply fork the branch and pull the files or download the code and create a new C# project.

## Creating a Game
Create a new C# Class called MyGame.cs and paste the following code into it:
```cs
using System.Windows.Forms;

using CFG;
using CFG.Objects;

class MyGame : Game // extend the game class
{

  Sprite player = new Sprite(10, 10, 10, 10); // create a simple sprite to act as the player

  public override void GameLogic() // put your game code here
  {
  }

  public override void InitaliseGame() // add the sprite or initalise other game resources
  {
    AddSprite(player);
  }

  public override void OnKeyDown(object sender, KeyEventArgs e) // handle key presses
  {
  }
  
}

```

Now that we have a sprite, lets allow him to move about our screen.
Find the following method in your file
```cs
public override void OnKeyDown(object sender, KeyEventArgs e) // handle key presses
{
}
```

Now insert the folowing into it:
```cs
public override void OnKeyDown(object sender, KeyEventArgs e) // handle key presses
{
  switch (e.KeyCode)
  {
    case Keys.W:
      player.position.y -= 10;
      break;
    case Keys.S:
      player.position.y += 10;
      break;
    case Keys.A:
      player.position.x -= 10;
      break;
    case Keys.D:
      player.position.x += 10;
      break;
  }
}
```

And Voila! You have a game where you can move a sqaure around the screen!
