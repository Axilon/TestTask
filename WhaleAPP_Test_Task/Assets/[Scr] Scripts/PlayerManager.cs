using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private LayerMask layerMask;

	void Update () {
        if (GameController.instance.GetGameStartedStatus() && !GameController.instance.GetGameFinishedStatus() && Input.GetMouseButtonDown(0))
        {
            RayCast();
        }
    }
    private void RayCast()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(screenPosition, Vector2.zero,300,layerMask);
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Unit>().ReturnToPool();
                GameController.instance.UpdateScore(1);
            }
            else if(hit.collider.tag == "Citizen")
            {
                GameController.instance.EndGame();
            }
        }
    }
}
