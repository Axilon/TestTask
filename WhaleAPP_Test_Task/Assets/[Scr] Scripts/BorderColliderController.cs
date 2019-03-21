using UnityEngine;

public class BorderColliderController : MonoBehaviour {
    public bool UpdateForY;

	void Start () {
        if (UpdateForY)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(20, transform.parent.GetComponent<RectTransform>().rect.height);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(transform.parent.GetComponent<RectTransform>().rect.width, 20);
        }
        
	}
}
