using UnityEngine;
using UnityEngine.UI;

public class UI_ConstructionArea : MonoBehaviour
{
    [SerializeField]
    Slider _slider;

	protected PlayerController _player { get; set; }

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter");

		PlayerController pc = other.GetComponent<PlayerController>();
		if (pc != null)
		{
			_player = pc;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("OnTriggerStay");
		_slider.value += 0.1f * Time.deltaTime;
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit");

		PlayerController pc = other.GetComponent<PlayerController>();
		if (pc != null)
		{
			_player = null;
		}
	}
}
