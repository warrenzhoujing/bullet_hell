using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
	public Vector3[] localWaypoints;
	Vector3[] globalWaypoints;
	public float speed;
	public bool Cyclic;
	public float WaitTime;
	[Range(0, 6)]
	public float EaseValue;
	int fromWaypointIndex;
	float percentBetweenWaypoints;
	float nextMoveTime;

	void Start () {
		globalWaypoints = new Vector3[localWaypoints.Length];
		for (int i = 0; i  < localWaypoints.Length; i++) {
			globalWaypoints[i] = localWaypoints[i] + transform.position;
		}
	}

	void Update () {
		Vector3 velocity = CalculateMovement();
		transform.Translate(velocity);
	}

	float Ease (float x) {
		float a = EaseValue + 1;
		return Mathf.Pow(x, a)/(Mathf.Pow(x,a) + Mathf.Pow(1 - x , a));
	}

	Vector3 CalculateMovement () {

		if (Time.time < nextMoveTime) {
			return Vector3.zero;
		}

		fromWaypointIndex %= globalWaypoints.Length;
		int toWaypointIndex = (fromWaypointIndex + 1) % globalWaypoints.Length;
		float distanceBetweenWaypoints = Vector3.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
		percentBetweenWaypoints += Time.deltaTime * speed / distanceBetweenWaypoints;
		percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);

		float easePercentBetweenWaypoints = Ease(percentBetweenWaypoints);
		Vector3 newPos = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], easePercentBetweenWaypoints);
		if (percentBetweenWaypoints >= 1) {
			percentBetweenWaypoints = 0;
			fromWaypointIndex ++;
			if (!Cyclic) {
				if (fromWaypointIndex >= globalWaypoints.Length - 1) {
					fromWaypointIndex = 0;
					System.Array.Reverse(globalWaypoints);
				}
			}
			nextMoveTime = Time.time + WaitTime;
		}
		return newPos - transform.position;
	}
}
