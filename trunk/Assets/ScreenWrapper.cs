using UnityEngine;

public class ScreenWrapper : MonoBehaviour {
		
	public Vector2 wrap;
	public Vector2 wrapMax;
	
	void Awake () {
		Vector3 wrapmin = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.y));
		wrap = new Vector2(wrapmin.x - 4, wrapmin.z - 4);
		Vector3 wrapmax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.y));
		wrapMax = new Vector2(wrapmax.x + 4, wrapmax.z + 4);
	}
	
	void Update () {
		Vector3 newPosition = transform.position;
		if(transform.position.x > wrapMax.x) {
			newPosition.x = wrap.x;	
		}
		if(transform.position.x < wrap.x) {
			newPosition.x = wrapMax.x;	
		}
		if(transform.position.z > wrapMax.y) {
			newPosition.z = wrap.y;	
		}
		if(transform.position.z < wrap.y) {
			newPosition.z = wrapMax.y;	
		}
		transform.position = newPosition;
	}
	
}
