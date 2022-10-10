using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using TMPro;

public class EnemyFactory : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    List<Enemy> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        var enemyTypes = Assembly.GetAssembly(typeof(Enemy)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract&& myType.IsSubclassOf(typeof(Enemy)));
        
        enemyList = new List<Enemy>();

        foreach(var type in enemyTypes)
        {
            var tempType = Activator.CreateInstance(type) as Enemy;
            enemyList.Add(tempType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Enemy GetEnemy(string enemyType)
    {
        foreach (Enemy enemy in enemyList)
        {
            if(enemy.Name == enemyType)
            {
                Debug.Log("Enemy found");
                var target = Activator.CreateInstance(enemy.GetType());
            }
        }
    }
    void ButtonPanel()
    {
        foreach(Enemy enemy in enemyList)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.gameObject.name = enemy.Name + "Button";
            button.GetComponentsInChildren<TextMeshProUGUI>().text = enemy.Name;
        }
    }
}
