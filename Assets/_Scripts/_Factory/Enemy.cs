using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string Name { get; }

    public abstract GameObject Create(GameObject prefab);
}

public class Crab:Enemy
{
    public override string Name => "Crab";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Crab enemy is created");
        return enemy;
    }
}
public class Monster : Enemy
{
    public override string Name => "Monster";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Monster enemy is created");
        return enemy;
    }
}