using UnityEngine;

public class WatchFood : MonoBehaviour
{
    void Update()
    {
        LookAtFood();
    }

    private void LookAtFood()
    {
        GameObject food = GameObject.Find("Food");
        if (food != null)
        {
            Vector2 direction = new Vector2(food.transform.position.x - transform.position.x, food.transform.position.y - transform.position.y);
            transform.up = -direction;
        }
    }
}