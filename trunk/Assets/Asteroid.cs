using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float force;
	public float rotationSpeed;
	public int generation;
	
	void Start () {
		//rigidbody.AddForce(Vector3.forward * force);
		rigidbody.drag = 0;
		rigidbody.AddTorque(Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, ForceMode.Impulse);
		//foreach (Rigidbody child in GetComponentsInChildren<Rigidbody>()) {
		//	if(child.gameObject.name != "AsteroidFull") {
		//		child.gameObject.active = false;
		//	}	
		//}
	}
	
	
	void Update () {
		if(!renderer.isVisible)	 {
		//	DestroyObject(gameObject);
		}
	}
}
