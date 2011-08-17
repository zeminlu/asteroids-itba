using UnityEngine;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour {

	public float force;
	public float rotationSpeed;
	public int initialAsteroids;
	public GameObject asteroid;
	public GameObject warpZones;
	private List<GameObject> activeAsteroids;
	private List<GameObject> pasiveAsteroids;
	private Vector3 fullScale;
	private Vector3 mediumScale;
	private Vector3 smallScale;
	
	void Start () {
		fullScale = new Vector3(1, 1, 1);
		mediumScale = new Vector3(0.3F, 0.3F, 0.3F);
		smallScale = new Vector3(0.1F, 0.1F, 0.1F);
		warpZones = (GameObject)Instantiate(warpZones);
		activeAsteroids = new List<GameObject>(initialAsteroids);
		pasiveAsteroids = new List<GameObject>(initialAsteroids * 12);
		Transform[] positions = warpZones.transform.GetComponentsInChildren<Transform>();
		Debug.Log(positions.Length);
		
		for (int i = 0 ; i < initialAsteroids ; ++i){
			GameObject tmpAsteroid = (GameObject)Instantiate(asteroid);
			tmpAsteroid.transform.position = positions[i + 1].position;
			tmpAsteroid.transform.rotation = warpZones.transform.rotation;
			tmpAsteroid.active = true;
			tmpAsteroid.transform.rigidbody.AddForce(transform.forward * Time.deltaTime * force);	
			activeAsteroids.Add(tmpAsteroid);
		}
		
		for (int i = 0 ; i < initialAsteroids * 12 ; ++i){
			GameObject tmpAsteroid = (GameObject)Instantiate(asteroid);
			foreach (Transform child in tmpAsteroid.GetComponentsInChildren<Transform>()) {
				child.gameObject.active = false;
			}
			tmpAsteroid.active = false;
			pasiveAsteroids.Add(tmpAsteroid);
		}
	}
	
	
	void Update () {
		//if(!renderer.isVisible)	 {
		//	DestroyObject(gameObject);
		//}
	}
	
	public void hitAsteroid(GameObject otherAsteroid){
		Vector3 tmpPostition = otherAsteroid.transform.position;
		GameObject tmpAsteroid;
		Transform[] positions = warpZones.transform.GetComponentsInChildren<Transform>();
		
		activeAsteroids.Remove(otherAsteroid);
		foreach (Transform child in otherAsteroid.GetComponentsInChildren<Transform>()) {
			child.gameObject.active = false;
		}
		otherAsteroid.active = false;

		
		for (int i = 0 ; i < 3 ; ++i){
			if (pasiveAsteroids.Count == 0){
				tmpAsteroid = (GameObject)Instantiate(asteroid);
			} else {
				tmpAsteroid = pasiveAsteroids[0];
				pasiveAsteroids.RemoveAt(0);
			}
			Quaternion tmpRotation = otherAsteroid.transform.rotation;
			tmpRotation.x += 120 * i;
			tmpAsteroid.transform.rotation = tmpRotation;
			
			if (otherAsteroid.transform.localScale.Equals(fullScale)){
				tmpAsteroid.transform.position = tmpPostition;
				tmpAsteroid.transform.localScale = mediumScale;
			} else if (otherAsteroid.transform.localScale.Equals(mediumScale)){
				tmpAsteroid.transform.position = tmpPostition;
				tmpAsteroid.transform.localScale = smallScale;
			} else {
				tmpAsteroid.transform.position = positions[RandomNumber(1, positions.Length - 1)].position;
				tmpAsteroid.transform.localScale = fullScale;
			}
			
			tmpAsteroid.active = true;
			foreach (Transform child in tmpAsteroid.GetComponentsInChildren<Transform>()) {
				child.gameObject.active = true;
			}
			tmpAsteroid.transform.rigidbody.AddForce(transform.forward * Time.deltaTime * force);	
			activeAsteroids.Add(tmpAsteroid);
		}
		otherAsteroid.transform.localScale = fullScale;
		pasiveAsteroids.Add(otherAsteroid);
		
	}
	
	private int RandomNumber(int min, int max){
		System.Random random = new System.Random();
		return random.Next(min, max);
	}
}
