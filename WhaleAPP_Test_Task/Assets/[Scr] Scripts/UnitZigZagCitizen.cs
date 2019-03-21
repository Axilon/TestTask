public class UnitZigZagCitizen : UnitZigZag {

    protected override void EndGame()
    {
        isAlive = false;
        ReturnToPool();
    }
}
