using Arkanoid.GameElements;

namespace Arkanoid
{
    public class BallEscapedSignal
    {
        public BallFacade BallRef;
    }

    public class BrickDestroyedSignal
    {
        public int Id;
    }

    public class GameStateChanged
    {

    }

    public class GameLost
    {
        public int Score;
    }

    public class GamePaused
    {

    }
}
