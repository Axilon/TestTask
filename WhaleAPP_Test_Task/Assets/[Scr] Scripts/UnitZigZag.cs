using UnityEngine;

public class UnitZigZag : Unit {
    private float moveTime;
    private float timer;
    private Vector2 moveDirection;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(collision.gameObject.tag == "Border")
        {
            CheckCollision(collision);
        }
    }
    protected override void InitializeUnit()
    {
        SetMoveDirection();
        base.InitializeUnit();
    }
    protected override void TranslateUnit()
    {
        if (timer <= moveTime)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            SetMoveDirection();
        }
    }
    private void SetMoveDirection(int minDir = -1, int maxDir = 2)
    {
        timer = 0;
        moveTime = Random.Range(1, 3);
        moveDirection = new Vector2(Random.Range(minDir, maxDir), -1);
    }
    private void CheckCollision(Collision2D collision)
    {
        float position = transform.position.x - collision.transform.position.x;
        if (position < 0)
        {
            SetMoveDirection(-1, 0);
        }
        else if (position > 0)
        {
            SetMoveDirection(1, 2);
        }
    }
}
