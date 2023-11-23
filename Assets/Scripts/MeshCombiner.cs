using UnityEngine;

namespace Spherum.Test
{
	public class MeshCombiner : MonoBehaviour
	{
		[SerializeField] private MeshRenderer[] spheres;
		[SerializeField] private MeshFilter targetMesh;

		[ContextMenu("Combine Meshes")]
		private void CombineMeshes()
		{
			var combine = new CombineInstance[spheres.Length];
			for (var i = 0; i < combine.Length; i++)
			{
				var sphereMesh = spheres[i].GetComponent<MeshFilter>().sharedMesh;
				var newMesh = CreateMeshWithUVOffset(i, sphereMesh);

				combine[i].mesh = newMesh;
				combine[i].transform = spheres[i].transform.localToWorldMatrix;
			}

			var mesh = new Mesh();
			mesh.CombineMeshes(combine);
			targetMesh.mesh = mesh;
		}

		private static Mesh CreateMeshWithUVOffset(in int index, in Mesh fromMesh)
		{
			var offset = new Vector2(index % 5, Mathf.FloorToInt(index / 5f));
			var uv = new Vector2[fromMesh.uv.Length];
			for (var j = 0; j < fromMesh.uv.Length; j++)
			{
				uv[j] = fromMesh.uv[j] + offset;
			}

			var newMesh = new Mesh
			{
				vertices = fromMesh.vertices,
				triangles = fromMesh.triangles,
				normals = fromMesh.normals,
				tangents = fromMesh.tangents,
				bounds = fromMesh.bounds,
				uv = uv
			};
			
			return newMesh;
		}
	}
}