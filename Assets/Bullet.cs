using UnityEngine;

public class Bullet : MonoBehaviour {
		
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		if(!other.CompareTag("Player")) {
			
		}
	}
}
