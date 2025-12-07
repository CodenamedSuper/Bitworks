using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class GameManager
{
    public Level Level;
    public void SetLevel(Level level)
    {
        Level = level;
        Level.Start();
    }
    public void Update()
    {
        Level.Update();
        Level.Animate();
    }
    public void Draw()
    {
        Level.Draw();
    }
}
