using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float spawnTime = 2.0f;
    public float spawnCount = 5;

    public GameObject prefab;
    public Transform bugMove;

    private int score;
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnTime);
    }

    void Update()
    {

    }

    void Spawn()
    {
        Vector3 position = new Vector3();

        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Camera.main.aspect;
        float angle = 0.0f;

        for (int i = 0; i < spawnCount; ++i)
        {
            switch (i % 4)
            {
                case 0:
                    position.x = -screenHalfWidth;
                    position.y = Random.Range(-screenHalfHeight, screenHalfHeight);
                    position.z = Random.Range(2, 5);
                    angle = -90.0f;
                    break;

                case 1:
                    position.x = screenHalfWidth;
                    position.y = Random.Range(-screenHalfHeight, screenHalfHeight);
                    position.z = Random.Range(2, 5);
                    angle = 90.0f;
                    break;

                case 2:
                    position.x = Random.Range(-screenHalfWidth, screenHalfWidth);
                    position.y = screenHalfHeight;
                    position.z = Random.Range(2, 5);
                    angle = 180.0f;
                    break;

                case 3:
                    position.x = Random.Range(-screenHalfWidth, screenHalfWidth);
                    position.y = -screenHalfHeight;
                    position.z = Random.Range(2, 5);
                    angle = 0.0f;
                    break;
            }

            GameObject go = Instantiate(prefab, bugMove);

            go.transform.position = position;
            go.transform.Rotate(0.0f, 0.0f, angle);

            Bug bug = go.GetComponent<Bug>();
            bug.bugDeadEvent.AddListener(OnBugDead);
        }
    }

    void OnBugDead()
    {
    }
}
