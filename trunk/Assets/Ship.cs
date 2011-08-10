using UnityEngine;

public class Ship : MonoBehaviour {
	
	public GameObject bullet;
	public float force;
	public float rotationSpeed;
	public float shootStrengh;
	void Start () {
		
	}
	
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		bool vertical = Input.GetButton("Vertical");
		transform.Rotate(new Vector3(horizontal*Time.deltaTime*rotationSpeed,0,0));
		
		if(vertical) {
			rigidbody.AddForce(transform.forward * Time.deltaTime * force);	
		}
		
		
		if(Input.GetKeyDown(KeyCode.Space)) {
			GameObject bulletGameObject = (GameObject)Instantiate(bullet);
			Transform anotherTransform = bulletGameObject.transform;
			anotherTransform.position = transform.position;
			anotherTransform.rotation = transform.rotation;	
			anotherTransform.rigidbody.AddForce(transform.forward * Time.deltaTime * shootStrengh);	
		}
		
	}
}