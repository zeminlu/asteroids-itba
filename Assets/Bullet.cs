using UnityEngine;

public class Bullet : MonoBehaviour {
	
	public AsteroidManager asteroidManager;
	
	void Start () {
		this.asteroidManager = SingletonManager.GetAsteroidManager();
	}
	
	void Update () {
		if(!renderer.isVisible)	 {
			DestroyObject(gameObject);	
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Asteroid")) {
			DestroyObject(gameObject);
			GameObject asteroid = other.gameObject;
			asteroidManager.hitAsteroid(asteroid);
		}
	}
}
