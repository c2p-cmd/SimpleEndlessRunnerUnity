﻿using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

    public GameObject obstacle;

    private void Start() => Instantiate(obstacle, transform.position, Quaternion.identity);
}
