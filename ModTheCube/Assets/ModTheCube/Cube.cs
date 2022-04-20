using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	public MeshRenderer Renderer;

	private Vector3 minV = new Vector3(-5, -5, -5);
	private Vector3 maxV = new Vector3(5, 7, 5);

	private float minx = -5f;
	private float maxx = 10f;

	private float miny = -5f;
	private float maxy = 10f;

	private float minz = -5f;
	private float maxz = 10f;



	void Start()
	{

	}

	void Update()
	{
		var randomV = new Vector3(Random.Range(minV.x, maxV.x) * Time.deltaTime, Random.Range(minV.y, maxV.y), Random.Range(minV.z, maxV.z));
		transform.position = randomV;
		transform.localScale = Vector3.one * 1.3f;
		Material material = Renderer.material;
		material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); ;
		transform.Rotate(Random.Range(minx, maxx) * Time.deltaTime, Random.Range(miny, maxy), Random.Range(minz, maxz));
	}
}
