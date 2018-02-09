using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    float TOUCH_SPEED = 2.8f;
    float KEYBOARD_SPEED = 0.25f;
    float KEYBOARD_MOVE_LEN = 1f;
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        MoveByKeyBoard();
        MoveByTouch();


            if ((transform.position.x >= 4 || transform.position.x <= -4)
        || (transform.position.y >= 5.5 || transform.position.y <= -5.5))
            {
            GameObject.Find("Main Camera").GetComponent<SceneControl>().now = 0;
            this.transform.position = new Vector3(0, -4, 0);
        }

        
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
        //this.transform.position = newPlayerPosition;
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

                newPlayerPosition.x += mouseX* TOUCH_SPEED * Time.deltaTime;
                newPlayerPosition.y += mouseY* TOUCH_SPEED * Time.deltaTime;
                this.transform.position = newPlayerPosition;
            }
        }
    }
}
