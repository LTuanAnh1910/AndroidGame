using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TestEnemy : MonoBehaviour
{
	// Start is called before the first frame update
	//Khu vực đặt bi
	//kéo Rigid của player vào biến này
	public Rigidbody2D rb;
	public int health = 1;
	//Nhận giá trị điều khiển từ bàn phím
	public Vector2 moveInput;
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		//Khu vực xử lý dữ liệu khi trò chơi chạy
		//Khu vực này được gọi mỗi frame 1 lần

		rb.AddForce(transform.right * 50);

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void FixedUpdate()
	{
		//Xử lý tương tác giữa bàn phím và đối tượng
		rb.velocity = new Vector2(moveInput.x * 1000 * Time.deltaTime, rb.velocity.y);
	}
}
