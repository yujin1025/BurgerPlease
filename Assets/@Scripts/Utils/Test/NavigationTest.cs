using UnityEngine;

public class NavigationTest : MonoBehaviour
{
	UnityEngine.AI.NavMeshAgent _navMeshAgent;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		_navMeshAgent.SetDestination(Vector3.zero);
	}

	// Update is called once per frame
	void Update()
	{
		// 중력 작용 
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
}
