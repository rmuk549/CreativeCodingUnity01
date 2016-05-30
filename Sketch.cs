    using UnityEngine;
    using Pathfinding.Serialization.JsonFx;
	using System.Collections;

	public class Sketch : MonoBehaviour {

		public GameObject myPrefab;
	string _WebsiteURL = "http://Rmuk549.azurewebsites.net/tables/Ass2?zumo-api-version=2.0.0";

	void Start () {

		string Response = Request.GET(_WebsiteURL);


		if (string.IsNullOrEmpty(Response))
		{
			return;
		}

		Trello[] trellos = JsonReader.Deserialize<Trello[]>(Response);

		//---------------------

		/*rmuk549*/

		int i = 0;

		/*rmuk549*/

		//----------------------


		foreach (Trello trello in trellos)
		{

			Debug.Log(trello.Title);

			//---------------------

			/*rmuk549*/

			int totalCubes = 15;
			float totalDistance = 3.2f;

			//Sin Distro

			float perc = i / (float)totalCubes;
			float sin = Mathf.Sin (perc * Mathf.PI/2);

			float x = 1.8f + sin * totalDistance;
			float y = 5.0f;
			float z = 0.0f;

			var newcube = (GameObject)Instantiate (myPrefab, new Vector3 (x, y, z), Quaternion.identity);
			newcube.GetComponent<CubeCode>().SetSize(1.0f*(1.0f - perc));	
			newcube.GetComponent<CubeCode> ().RotateSpeed = .45f + perc;
			newcube.GetComponentInChildren<TextMesh> ().text = trello.AddedAt;

			i++;

			/*rmuk549*/

			//----------------------
		}
	}

	// Update is called once per frame
	void Update () {

	}
}

// ----//


