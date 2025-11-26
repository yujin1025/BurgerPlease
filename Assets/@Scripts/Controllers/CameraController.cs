using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Transform _target;

	private Vector3 _offset;

	void Start()
	{
		_offset = transform.position - _target.position;
	}

	/*
	 * LateUpdate : 모든 Update가 끝난 직후에 같은 프레임 안에서 실행
	 * 카메라 이동을 Update에 넣으면 실행 순서 보장이 안되므로
	 * 카메라 이동 -> 플레이어 이동 순으로 될 수도 있음. 덜덜 떨리는 현상 발생 가능 
	 */
	void LateUpdate()
	{
		// 타겟이 움직이면 카메라도 똑같은 간격을 유지하며 이동
		transform.position = _offset + _target.position;
	}
}
