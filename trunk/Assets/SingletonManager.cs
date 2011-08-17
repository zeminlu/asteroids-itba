using UnityEngine;

public class SingletonManager
{
    public static AsteroidManager GetAsteroidManager()
    {
        return GameObject.FindObjectOfType(typeof(AsteroidManager)) as AsteroidManager;
    }
}
