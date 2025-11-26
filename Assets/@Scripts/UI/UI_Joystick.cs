using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private GameObject _background;

	[SerializeField]
	private GameObject _cursor;

	private float _radius;
	private Vector2 _touchPos;

	public void Start()
	{
		// 조이스틱 배경 이미지 높이의 1/3만큼을 이동 반경으로 설정
		// RectTransform은 UI용 Transform
		_radius = _background.GetComponent<RectTransform>().sizeDelta.y / 3;
	}

	// 터치 시작
	public void OnPointerDown(PointerEventData eventData)
	{
		// 터치한 위치(eventData.position)로 조이스틱 배경, 커서를 이동
		_background.transform.position = eventData.position;
		_cursor.transform.position = eventData.position;
		_touchPos = eventData.position;
	}

	// 터치 종료 
	public void OnPointerUp(PointerEventData eventData)
	{
		// 커서를 다시 원점으로 복귀
		_cursor.transform.position = _touchPos;

		// 캐릭터 정지 
		GameManager.Instance.JoystickDir = Vector2.zero;
	}

	// 드래그 중 
	public void OnDrag(PointerEventData eventData)
	{
		// 방향 벡터 : 현재 터치 위치 - 처음 터치한 중심점
		Vector2 touchDir = (eventData.position - _touchPos);

		float moveDist = Mathf.Min(touchDir.magnitude, _radius);
		// 단위 벡터 
		Vector2 moveDir = touchDir.normalized;
		Vector2 newPosition = _touchPos + moveDir * moveDist;
		_cursor.transform.position = newPosition;

		GameManager.Instance.JoystickDir = moveDir;
	}
}
