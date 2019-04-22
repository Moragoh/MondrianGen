using System.Collections;
using UnityEngine;

public class RectSettings : MonoBehaviour {

	static public Vector2 startPos;
	static public Vector2 endPos;
	static public Vector3 centerPos;

	private float startX;
	private float startY;
	private float endX;
	private float endY;
	private float currentX;
	private float currentY;

	private void Start() {

	}

	// Instantiate Square
	private void SetPositions() {
		startPos = new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), 0);
		endPos = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.width), 0);

		startX = startPos.x;
		startY = startPos.y;
		endX = endPos.x;
		endY = endPos.y;
		currentX = startX;
		currentY = startY;

		centerPos = (startPos + endPos) / 2;
	}


	private IEnumerator DrawRect() {

		/*
		if (currentX < endX) {
			currentX += 0.1f;
		} else if (currentX > endX) {
			while (currentX > endX) {
				currentX -= 0.1f;
			}
		}

		if (currentY < endY) {
			while(currentY < endY) {
				currentY += 0.1f;
			}
		} else if (currentY > endY) {
			while (currentY > endY) {
				currentY -= 0.1f;
			}
		}
		*/
		yield return new WaitForSeconds(0.1f);

	}

	// Update is called once per frame
	void Update () {

		
	}
}
