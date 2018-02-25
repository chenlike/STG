using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    float KEYBOARD_SPEED = 0.002f;
    float KEYBOARD_MOVE_LEN = 0.06f;
    const float KEYBOARD_MOVE_LEN_LOW = 0.03f;
    const float KEYBOARD_MOVE_LEN_HIGH = 0.06f;
    void Start()
    {

    }
    // Update is called once per frame
    float ti = 0;
    void Update()
    {
        MoveByKeyBoard();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {

            this.transform.position = new Vector3(0, -4, 0);
            var objs = GameObject.FindGameObjectsWithTag("EnemyBullet");

            foreach (GameObject obj in objs)
            {
                Bullet blt = obj.GetComponent<Bullet>();
                if (blt!=null)
                    blt.DestroyMe();
            }
        }
    }

    /// <summary>
    /// 键盘移动
    /// </summary>
    void MoveByKeyBoard()
    {

        Vector3 newPlayerPosition = transform.position;
        KEYBOARD_MOVE_LEN= KEYBOARD_MOVE_LEN_HIGH;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            KEYBOARD_MOVE_LEN = KEYBOARD_MOVE_LEN_LOW;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPlayerPosition.y += KEYBOARD_MOVE_LEN;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPlayerPosition.y -= KEYBOARD_MOVE_LEN;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPlayerPosition.x -= KEYBOARD_MOVE_LEN;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPlayerPosition.x += KEYBOARD_MOVE_LEN;
        }
        /*
        if (newPlayerPosition.x < -2.752 || newPlayerPosition.x > 2.752)
        {
            newPlayerPosition.x = transform.position.x;
        }
        if (newPlayerPosition.y < -4.958 || newPlayerPosition.y > 4.958)
        {
            newPlayerPosition.y = transform.position.y;
        }
        */
        if (newPlayerPosition == transform.position) return;
        transform.position = newPlayerPosition;

    }




}
