using UnityEngine;

public class ScreenWrapper : MonoBehaviour {
		
	public Vector2 wrap;
	public Vector2 wrapMax;
	public float distanceToWrap;
	
	void Awake () {
		Vector3 wrapmin = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.y));
		wrap = new Vector2(wrapmin.x - 1, wrapmin.z - 1);
		Vector3 wrapmax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.y));
		wrapMax = new Vector2(wrapmax.x + 1, wrapmax.z + 1);
	}
	
	void Update () {
		Vector3 newPosition = transform.position;
		if(transform.position.x > wrapMax.x + distanceToWrap) {
			newPosition.x = wrap.x - distanceToWrap;	
		}
		if(transform.position.x < wrap.x - distanceToWrap) {
			newPosition.x = wrapMax.x + distanceToWrap;	
		}
		if(transform.position.z > wrapMax.y + distanceToWrap) {
			newPosition.z = wrap.y - distanceToWrap;	
		}
		if(transform.position.z < wrap.y - distanceToWrap) {
			newPosition.z = wrapMax.y + distanceToWrap;	
		}
		transform.position = newPosition;
	}
	
}
