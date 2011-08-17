using UnityEngine;

public class Bullet : MonoBehaviour {
		
	void Start () {
		
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
			foreach (Transform child in asteroid.transform) {
				Debug.Log("asdf");
				//if(child.gameObject.rigidbody != null) {
					child.gameObject.active = true;
				//}
			}
			//asteroid.active = false;
		}
	}
}
