using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Rigidbody rb;
	public int speed;
	private int count;
	public Text countText;
	public Text winText;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 mouvment = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(mouvment * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Cube") {
			count++;
			SetCountText();
			Destroy(other.gameObject);
			int randomNumber = Random.Range(0,7);
			if (randomNumber == 0) {
				speed += 100;
			} else if (randomNumber == 1) {
				speed -= 100;
			} else if (randomNumber == 2) {
				rend.enabled = true;
				rend.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			} else if (randomNumber == 3) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
			} else if (randomNumber == 4) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
			} else if (randomNumber == 5) {
				transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
			} else if (randomNumber == 6) {
				speed = 600;
			}

		} else if (other.gameObject.tag == "Loose") {
			Application.LoadLevel(0);
		}
	}

	void SetCountText() {
		countText.text = "Score : " + count.ToString();
		if (count >= 78) {
			winText.text = "WIN!!!!";
		}
	}
}
