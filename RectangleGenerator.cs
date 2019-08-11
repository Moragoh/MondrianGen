using System.Collections;
using UnityEngine;

public class RectangleGenerator : MonoBehaviour {

	public GameObject redSquare;
	public GameObject blueSquare;
	public GameObject blackSquare;
	public GameObject yellowSquare;
	public GameObject whiteSquare;
	public GameObject currentSquare;
	public GameObject squareParent;


	private GameObject rectangle;
	private Vector2 startPos;
	private Vector2 endPos;
	private Vector3 centerPos;
	private float startX;
	private float startY;
	private float endX;
	private float endY;
	private float currentX;
	private float currentY;

	// Instantiate Square
	private void SetPositions() {
		print(Screen.height.ToString());
		print(Screen.width.ToString());
		startPos = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.height),0);
		endPos = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.width),0);

		startX = startPos.x;
		startY = startPos.y;
		endX = endPos.x;
		endY = endPos.y;
		currentX = startX;
		currentY = startY;

		centerPos = (startPos + endPos) / 2;

		int squareNum = Random.Range(0,6);

		switch (squareNum) {

		case 0:
			currentSquare = blueSquare;
			break;
		case 1:
			currentSquare = redSquare;
			break;
		case 3:
			currentSquare = blackSquare;
			break;
		case 4:
			currentSquare = yellowSquare;
			break;
		case 5:
			currentSquare = whiteSquare;
			break;

		}
	}


	private void Start() {
		StartCoroutine(GenerateRect());
	}

	private void Update() {
		if(Input.GetKey("escape")) {
			Application.Quit();
		}
	}

	IEnumerator GenerateRect() {
		SetPositions();

		float sizeX = Mathf.Abs(startPos.x - endPos.x);
		float sizeY = Mathf.Abs(startPos.y - endPos.y);

		if (sizeX == sizeY) {
			foreach (Transform child in squareParent.transform) {
				GameObject.Destroy(child.gameObject);
			}

			rectangle = Instantiate(currentSquare,new Vector3(startX,startY,0),Quaternion.identity);
			rectangle.transform.SetParent(squareParent.transform,false);
			rectangle.GetComponent<RectTransform>().position = centerPos;
			rectangle.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX,sizeY);

			print("I can rest now");
			Time.timeScale = 0;

		} else {
			rectangle = Instantiate(currentSquare,new Vector3(startX,startY,0),Quaternion.identity);

			rectangle.transform.SetParent(squareParent.transform,false);
			rectangle.GetComponent<RectTransform>().position = centerPos;
			rectangle.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX,sizeY);
		}

		yield return new WaitForSeconds(0.1f);

		StartCoroutine(GenerateRect());
	}
}


