using UnityEngine;

public class EditorConfigFormattingTest : MonoBehaviour
{
	public int somePublicField;
	private int SomePrivateField;

	public int someProperty { get; private set; }


	private void Update()
	{
		Debug.Log("Update");
	}
}