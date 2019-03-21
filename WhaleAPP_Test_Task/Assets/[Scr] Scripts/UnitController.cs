using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    [SerializeField]
    private float spawningTime;
    private float spawningAreaX;
    private float spawningPointY;

    [SerializeField]
    private BoxCollider2D spawningBox;

    [SerializeField]
    private List<GameObject> prefabList;
    public Queue<GameObject> unitQueue;

    public delegate void EndGame();
    public EndGame endGame;

    public static UnitController instance;

    public void InitializePool()
    {
        unitQueue = new Queue<GameObject>();
        spawningAreaX = spawningBox.size.x / 3;
        spawningPointY = spawningBox.offset.y;
        for(int i = 0; i < 10; i++)
        {
            CreateUnit();
        }
    }
    public void ReturnUnitsToPool()
    {
        StopCoroutine("SpawnUnit");
        if(endGame != null)
        {
            endGame();
        }
    }
    public void RemoveUnitFromQueue()
    {
        if (unitQueue.Count <= 0)
        {
            CreateUnit();
        }
        GameObject unit = unitQueue.Dequeue();
        unit.transform.localPosition = new Vector2(Random.Range(-spawningAreaX, spawningAreaX), spawningPointY);
        unit.SetActive(true);
        spawningTime = Random.Range(2, 5);
    }
    public void AddUnitToQueue(GameObject unit)
    {
        unit.SetActive(false);
        unitQueue.Enqueue(unit);
    }
    public void SpawnUnits()
    {
        StartCoroutine("SpawnUnit");
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void CreateUnit()
    {
        AddUnitToQueue(Instantiate(prefabList[Random.Range(0, prefabList.Count)], transform));
    }
    private void OnApplicationQuit()
    {
        if (endGame != null)
        {
            endGame = null;
        }
    }
    private IEnumerator SpawnUnit()
    {
        while (!GameController.instance.GetGameFinishedStatus())
        {
            RemoveUnitFromQueue();
            yield return new WaitForSeconds(spawningTime);
        }
    }
}
