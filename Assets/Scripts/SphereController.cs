using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Spherum.Test
{
	public class SphereController : MonoBehaviour
	{
		[SerializeField] private Transform cube1, cube2;
		[SerializeField] private float spheresThreshold;
		[SerializeField] private float toSecondSceneThreshold;
		[SerializeField] private TextMeshProUGUI distanceText;
		[SerializeField] private Transform spheres;

		private void Update()
		{
			var distance = Vector3.Distance(cube1.position, cube2.position);
			if (distance < toSecondSceneThreshold)
			{
				SceneManager.LoadScene("Scene 2");
			}
			
			distanceText.SetText($"Между кубами {distance:N1}м");
			spheres.gameObject.SetActive(distance < spheresThreshold);
		}
	}
}
