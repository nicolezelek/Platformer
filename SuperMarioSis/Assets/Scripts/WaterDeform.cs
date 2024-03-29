﻿using UnityEngine;
using System.Collections;

public class WaterDeform : MonoBehaviour {
	MeshFilter mf;
	public float waveHeight = 0.001f;
	public float waveSize = 2f;
		
	public Vector3[] baseVertices;
	Vector3[] workingCopy;
	
	void Start () {
	mf = GetComponent<MeshFilter>();
	baseVertices = mf.mesh.vertices;
	}
	
	
	// Update is called once per frame
	void Update () {
		// every frame, start with a fresh copy of the untouched plane
	workingCopy = baseVertices;
		for ( int i=0; i<workingCopy.Length; i++){
			workingCopy[i] = baseVertices[i] + Vector3.up * Mathf.Sin ((Time.time + i) * waveSize) * waveHeight;
		}
		
		mf.mesh.vertices = workingCopy;
		mf.mesh.RecalculateNormals();
		for (int i = 0; i < mf.mesh.vertices.Length; i++){
			Debug.DrawRay (mf.mesh.vertices[i], mf.mesh.normals[i]);
		}
	}
}
