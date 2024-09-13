// Tracks all the upgrades and stats for the player


public class PlayerStats {
    public delegate void StatChange();
    public static StatChange goldChanged;

    static int _gold = 0;
    public static int gold {
        get { return _gold; }
        set { 
            if (goldChanged != null) goldChanged(); 
            _gold = value;
        }
    }

    public static int damage = 1;
    public static int speed = 10;
}
