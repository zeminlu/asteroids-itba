using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float force;
	public float rotationSpeed;
	
	void Start () {
		gameObject.
		rigidbody.AddForce(Vector3.forward * force);
		rigidbody.drag = 0;
		rigidbody.AddTorque(Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, ForceMode.Impulse);
		//Debug.Log(gameObject.transform.);
		//Rigidbody[] childs = GetComponentsInChildren<Rigidbody>();
		//foreach (Transform child in gameObject.transform){
		//	child.gameObject.active = false;
			
		//}
		//for (int i = 1 ; i < childs.Length ; ++i){
		//}		
	}
	
	void Update () {
		if(!renderer.isVisible)	 {
		//	DestroyObject(gameObject);	
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if(!other.CompareTag("Player")) {
			DestroyObject(gameObject);
		}
	}
}
