using UnityEngine;

public class Ship : MonoBehaviour {
	
	public GameObject bullet;
	public float force;
	void Start () {
		
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			GameObject bulletGameObject = (GameObject)Instantiate(bullet);
			Transform anotherTransform = bulletGameObject.transform;
			anotherTransform.position = transform.position;
			anotherTransform.rotation = transform.rotation;
			//anotherTransform.rigidbody.velocity = transform.rigidbody.velocity;
			anotherTransform.rigidbody.velocity = new Vector3(3F,0,0);
			//anotherTransform.rigidbody.velocity.Scale(new Vector3(1.5F,1.5F,1.5F));
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.rigidbody.AddForce(new Vector3(force,0,0));	
		}
	}
}