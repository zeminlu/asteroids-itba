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
	private float score = 0;
	private static int lowScore = 100;
	private static int mediumScore = 200;
	private static int highScore = 300;
	private int smallHits;
	private float localTime;
	private float timeTreshold;
	private Transform[] positions;
	
	void Start () {
		fullScale = new Vector3(0.8F, 0.8F, 1.2F);
		mediumScale = new Vector3(0.26F, 0.26F, 0.40F);
		smallScale = new Vector3(0.09F, 0.09F, 0.15F);
		localTime = 0F;
		timeTreshold = 30F;
		smallHits = 0;
		
		warpZones = (GameObject)Instantiate(warpZones);
		activeAsteroids = new List<GameObject>(initialAsteroids);
		pasiveAsteroids = new List<GameObject>(initialAsteroids * 12);
		positions = warpZones.transform.GetComponentsInChildren<Transform>();
		
		for (int i = 0 ; i < initialAsteroids ; ++i){
			GameObject tmpAsteroid = (GameObject)Instantiate(asteroid);
			tmpAsteroid.transform.position = positions[i + 1].position;
			tmpAsteroid.transform.rotation = warpZones.transform.rotation;
			tmpAsteroid.transform.localScale = fullScale;
			tmpAsteroid.transform.Rotate(new Vector3(0F, 120 * i - RandomNumber(0, 10) * 30F, 0F));
			tmpAsteroid.transform.rigidbody.AddForce(tmpAsteroid.transform.forward * Time.deltaTime * force * 4, ForceMode.Force);	
			activeAsteroids.Add(tmpAsteroid);
		}
		
		for (int i = 0 ; i < initialAsteroids * 12 ; ++i){
			GameObject tmpAsteroid = (GameObject)Instantiate(asteroid);
			tmpAsteroid.transform.localScale = fullScale;
			tmpAsteroid.SetActiveRecursively(false);
			pasiveAsteroids.Add(tmpAsteroid);
		}
		score = 0;
	}
	
	
	void Update () {
		if ((localTime += Time.deltaTime) >= timeTreshold){
			localTime = 0F;
			timeTreshold -= 0.3F;
			GameObject tmpAsteroid = (GameObject)Instantiate(asteroid);
			tmpAsteroid.transform.position = positions[RandomNumber(1, positions.Length - 1)].position;
			tmpAsteroid.transform.rotation = warpZones.transform.rotation;
			tmpAsteroid.transform.Rotate(new Vector3(0F, 180 - RandomNumber(0, 10) * 30F, 0F));
			tmpAsteroid.transform.rigidbody.AddForce(tmpAsteroid.transform.forward * Time.deltaTime * force * 4, ForceMode.Force);	
			activeAsteroids.Add(tmpAsteroid);
		}
	}
	
	public void hitAsteroid(GameObject otherAsteroid){
		Vector3 tmpPostition = otherAsteroid.transform.position;
		GameObject tmpAsteroid;
		
		activeAsteroids.Remove(otherAsteroid);
		otherAsteroid.SetActiveRecursively(false);
		
		if (otherAsteroid.transform.localScale.Equals(fullScale)) {
			score += highScore;	
		} else if (otherAsteroid.transform.localScale.Equals(mediumScale)) {
			score += mediumScore;	
		} else {
			score += lowScore;
		}
		
		if (otherAsteroid.transform.localScale.Equals(smallScale)){
			if (++smallHits >= 9){
				if (pasiveAsteroids.Count == 0){
					tmpAsteroid = (GameObject)Instantiate(asteroid);
				} else {
					tmpAsteroid = pasiveAsteroids[0];
					pasiveAsteroids.RemoveAt(0);
				}

				smallHits = 0;
				tmpAsteroid.transform.Rotate(new Vector3(0, 180 - RandomNumber(0, 10) * 30, 0));
				tmpAsteroid.transform.position = positions[RandomNumber(1, positions.Length - 1)].position;
				tmpAsteroid.transform.localScale = fullScale;
				tmpAsteroid.SetActiveRecursively(true);
				tmpAsteroid.rigidbody.AddForce(tmpAsteroid.transform.forward * Time.deltaTime * force * 4, ForceMode.Force);
				activeAsteroids.Add(tmpAsteroid);
			}
		} else {
			for (int i = 0 ; i < 3 ; ++i){
				if (pasiveAsteroids.Count == 0){
					tmpAsteroid = (GameObject)Instantiate(asteroid);
				} else {
					tmpAsteroid = pasiveAsteroids[0];
					pasiveAsteroids.RemoveAt(0);
				}
				
				tmpAsteroid.transform.Rotate(new Vector3(0, 120 * i - RandomNumber(0, 10) * 30, 0));
				
				if (otherAsteroid.transform.localScale.Equals(fullScale)){
					tmpAsteroid.transform.position = tmpPostition;
					tmpAsteroid.transform.localScale = mediumScale;
				} else if (otherAsteroid.transform.localScale.Equals(mediumScale)){
					tmpAsteroid.transform.position = tmpPostition;
					tmpAsteroid.transform.localScale = smallScale;
				}else {
					Debug.Log(otherAsteroid.transform.localScale);
				}
				
				tmpAsteroid.SetActiveRecursively(true);
				tmpAsteroid.rigidbody.AddForce(tmpAsteroid.transform.forward * Time.deltaTime * force * 4, ForceMode.Force);
				activeAsteroids.Add(tmpAsteroid);
			}
		}
		otherAsteroid.transform.localScale = fullScale;
		pasiveAsteroids.Add(otherAsteroid);	
	}
	
	private int RandomNumber(int min, int max){
		System.Random random = new System.Random();
		return random.Next(min, max);
	}
	
	void OnGUI () {
		GUI.Label(new Rect(Screen.width - 100, Screen.height - 40 , 90, 30), "Score: "+score);
	}
}
