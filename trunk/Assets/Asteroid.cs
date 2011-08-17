using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float rotationSpeed;
	public int generation;
	
	void Start () {
		rigidbody.drag = 0;
		rigidbody.AddTorque(Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, Time.deltaTime*rotationSpeed, ForceMode.Impulse);
		//rigidbody.AddForce(Vector3.forward * force);
	}
	
	
	void Update () {
		if(!renderer.isVisible)	 {
		//	DestroyObject(gameObject);
		}
	}
}
