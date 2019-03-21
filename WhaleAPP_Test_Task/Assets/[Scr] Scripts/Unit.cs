using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected bool isAlive;
   
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "End Game Zone")
        {
            EndGame();
        }
    }
    protected virtual void TranslateUnit()
    {
        transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
    }
    protected virtual void InitializeUnit()
    {
        isAlive = true;
        UnitController.instance.endGame += ReturnToPool;
        StartCoroutine(MoveUnit());
    }
    protected virtual void EndGame()
    {
        isAlive = false;
        GameController.instance.EndGame();
    }
    public void ReturnToPool()
    {
        UnitController.instance.AddUnitToQueue(gameObject);
    }
    private void OnEnable()
    {
        InitializeUnit();
    }
    private void OnDisable()
    {
        isAlive = false;
        UnitController.instance.endGame -= ReturnToPool;
    }
   
    private IEnumerator MoveUnit()
    {
        while (isAlive)
        {
            TranslateUnit();
            yield return null;
        }
    }
}
