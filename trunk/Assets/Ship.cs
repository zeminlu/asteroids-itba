using UnityEngine;

public class Ship : MonoBehaviour {
	
	public ParticleEmitter thrust;
	public GameObject bullet;
	public float force;
	public float rotationSpeed;
	public float shootStrengh;
	public GameObject menuManager;
	public GameObject explosion;

	
	void Start () {
		thrust.enabled = true;
		menuManager.SetActiveRecursively(false);
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			GameObject bulletGameObject = (GameObject)Instantiate(bullet);	
			Transform anotherTransform = bulletGameObject.transform;
			anotherTransform.position = transform.position;
			anotherTransform.rotation = transform.rotation;	
			anotherTransform.rigidbody.AddForce(transform.forward * Time.deltaTime * shootStrengh);	
		}
	}
	
	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		transform.Rotate(new Vector3(horizontal*Time.deltaTime*rotationSpeed,0,0));
		
		if (Mathf.Abs(vertical) > 0.15) {
			if(vertical > 0){
				thrust.maxEmission = 100;
				thrust.minEmission = 100;
			}
			rigidbody.AddForce(transform.forward * Time.deltaTime * force * vertical);	
		} else {
			thrust.maxEmission = 5;
			thrust.minEmission = 5;
		}

	}
	
	void OnDestroy () {
		menuManager.SetActiveRecursively(true);	
		GameObject go = (GameObject)Instantiate(explosion);
		go.transform.position = transform.position;
	}
}