using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static bool setTozero = false;

    [SerializeField]
    private BoxCollider2D gridArea;

    private void Start() {
        randomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Snake"))
        {
            randomizePosition();
        }
        ScoreManager.instance.countScore();
        setTozero = true;
    }

    void randomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
    
}
