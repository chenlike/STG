using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    float TOUCH_SPEED = 2.4f;
    float KEYBOARD_SPEED = 0.07f;
    float KEYBOARD_MOVE_LEN = 1f;
    Dictionary<string, bool> keyDown = new Dictionary<string, bool>();

	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        MoveByTouch();
        MoveByKeyBoard();
    }

    void OnTriggerEnter2D(Collider2D other)
    {



        if(other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            this.transform.position = new Vector3(0, -4, 0);
            var objs =GameObject.FindGameObjectsWithTag("EnemyBullet");
            GameObject.Find("Main Camera").GetComponent<SceneControl>().now = 0;
            foreach(GameObject a in objs)
            {
                Destroy(a);
            }
        }



    }

    /// <summary>
    /// 键盘移动
    /// </summary>
    void MoveByKeyBoard()
    {

        Vector2 newPlayerPosition = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPlayerPosition.y += KEYBOARD_MOVE_LEN * KEYBOARD_SPEED ;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPlayerPosition.y -= KEYBOARD_MOVE_LEN * KEYBOARD_SPEED ;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPlayerPosition.x -= KEYBOARD_MOVE_LEN * KEYBOARD_SPEED;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPlayerPosition.x += KEYBOARD_MOVE_LEN * KEYBOARD_SPEED;
        }


        if(newPlayerPosition.x< -2.752 || newPlayerPosition.x > 2.752)
        {
            newPlayerPosition.x = transform.position.x;
        }
        if (newPlayerPosition.y < -4.958 || newPlayerPosition.y > 4.958)
        {
            newPlayerPosition.y = transform.position.y;
        }
        this.transform.position = Vector2.Lerp(transform.position, newPlayerPosition, 0.3f);
    }
    /// <summary>
    /// 触屏移动
    /// </summary>
    void MoveByTouch()
    {
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                float mouseX = Input.GetAxis("Mouse X");    //手指水平移动的距离
                float mouseY = Input.GetAxis("Mouse Y");    //手指垂直移动的距离
                Vector2 newPlayerPosition = transform.position;

                newPlayerPosition.x += mouseX * TOUCH_SPEED * Time.deltaTime;
                newPlayerPosition.y += mouseY * TOUCH_SPEED * Time.deltaTime;
                this.transform.position = newPlayerPosition;
            }
        }
    }
}
