using UnityEngine;
using System.Collections;
using LMWidgets;

public class ButtonDemoToggleCreBack : ButtonToggleBase 
{
	public ButtonDemoGraphics onGraphics;
	public ButtonDemoGraphics offGraphics;
	public ButtonDemoGraphics midGraphics;
	public ButtonDemoGraphics botGraphics;
	
	public Color MidGraphicsOnColor = new Color(0.0f, 0.5f, 0.5f, 1.0f);
	public Color BotGraphicsOnColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);
	public Color MidGraphicsOffColor = new Color(0.0f, 0.5f, 0.5f, 0.1f);
	public Color BotGraphicsOffColor = new Color(0.0f, 0.25f, 0.25f, 1.0f);
	
	public Material MidGraphicsOnMaterial;
	public Material BotGraphicsOnMaterial;
	public Material MidGraphicsOffMaterial;
	public Material BotGraphicsOffMaterial;
	
	protected override void Start()
	{
		base.Start();
		
	}
	
	
	public override void ButtonTurnsOn()
	{
		TurnsOnGraphics();
	}
	
	public override void ButtonTurnsOff()
	{
		TurnsOffGraphics();
	}
	
	private void TurnsOnGraphics()
	{
		Debug.Log ("isOptions" + TranslateMenu.isOptions);
		Debug.Log ("isCredits" + TranslateMenu.isCredits);
		Debug.Log ("isOptBack" + TranslateMenu.isOptBack);
		Debug.Log ("isCreBack" + TranslateMenu.isCreBack);

		onGraphics.SetActive(true);
		offGraphics.SetActive(false);
		//midGraphics.SetColor(MidGraphicsOnColor);
		midGraphics.SetMaterial (MidGraphicsOnMaterial, MidGraphicsOnColor);
		//botGraphics.SetColor(BotGraphicsOnColor);
		botGraphics.SetMaterial(BotGraphicsOffMaterial, BotGraphicsOnColor);
		//Application.LoadLevel ("WalkingTerrainTest");
		//FadeControl.isFade = true;
		TranslateMenu.isCreBack = true;
		TranslateMenu.isCredits = false;
	}
	
	private void TurnsOffGraphics()
	{
		Debug.Log ("isOptions" + TranslateMenu.isOptions);
		Debug.Log ("isCredits" + TranslateMenu.isCredits);
		Debug.Log ("isOptBack" + TranslateMenu.isOptBack);
		Debug.Log ("isCreBack" + TranslateMenu.isCreBack);

		onGraphics.SetActive(false);
		offGraphics.SetActive(true);
		//midGraphics.SetColor(MidGraphicsOffColor);
		//botGraphics.SetColor(BotGraphicsOffColor);
		
		midGraphics.SetMaterial(MidGraphicsOffMaterial,MidGraphicsOffColor);
		botGraphics.SetMaterial(BotGraphicsOffMaterial,BotGraphicsOffColor);

		TranslateMenu.isCreBack = true;
		TranslateMenu.isCredits = false;
	}
	
	private void UpdateGraphics()
	{
		Vector3 position = transform.localPosition;
		position.z = Mathf.Min(position.z, m_localTriggerDistance);
		onGraphics.transform.localPosition = position;
		offGraphics.transform.localPosition = position;
		Vector3 bot_position = position;
		bot_position.z = Mathf.Max(bot_position.z, m_localTriggerDistance - m_localCushionThickness);
		botGraphics.transform.localPosition = bot_position;
		Vector3 mid_position = position;
		mid_position.z = (position.z + bot_position.z) / 2.0f;
		midGraphics.transform.localPosition = mid_position;
	}
	
	
	
	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		UpdateGraphics();
	}
}
