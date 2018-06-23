using UnityEngine;

public class DrunkCollider : MonoBehaviour
{




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "lady")
        {
            GameController.Instance.GameOver(win: true);

        }
        else if(collision.tag == "dude")
        {
            GameController.Instance.GameOver(win: false);
        }
    }
}
