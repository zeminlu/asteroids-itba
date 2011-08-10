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
		if(!other.CompareTag("Player")) {
			
		}
	}
}
