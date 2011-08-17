using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float rotationSpeed;
	public int generation;
	public GameObject explosion;
	
	void Start () {
		rigidbody.drag = 0;
		rigidbody.AddTorque(Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, ForceMode.Impulse);
		//rigidbody.AddForce(Vector3.forward * force);
	}
	
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Player")) {
			DestroyObject(other.gameObject);
			GameObject go = (GameObject)Instantiate(explosion);
			go.transform.position = other.transform.position;
		}
	}
	
	void Update () {
		if(!renderer.isVisible)	 {
		//	DestroyObject(gameObject);
		}
	}
}
