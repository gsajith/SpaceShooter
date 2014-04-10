using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public bool trigger; //end game trigger
	float wait_timer;
	public float level_timer;
	/*
	 * Defender power:
	 * 1. Frenzy: Boost defense fire rate. CD: 6s. Duration: 2s.
	 * 2. EMP: Disable attacker control. CD: 30s. Duration: 1s.
	 * 3. Force field: Create a field in the middle of the screen,
	 *    blocking all player shots. CD: 8s. Duration: 4s.
	 */
	public bool frenzy_trigger;
	public float frenzy_cd;
	public bool emp_trigger;
	public float emp_cd;
	public bool forcefield_trigger;
	public float forcefield_cd;
	public GameObject ffield;

	void Start() {
		frenzy_trigger = false;
		emp_trigger = false;
		wait_timer = 0;
	}

	void Update() {
		level_timer -= Time.deltaTime;
		if (level_timer <= 0)
				trigger = true;
		//use frenzy
		if(Input.GetKeyDown("o")){
			if(!frenzy_trigger && frenzy_cd<=0) {
				frenzy_trigger = true;
				frenzy_cd = 6f; //frenzy cooldown timer
			}
		}
		if(frenzy_cd>=0) { //frenzy cd timer running
			frenzy_cd-=Time.deltaTime;
			if(frenzy_cd<=4f && frenzy_trigger) //frenzy duration end
				frenzy_trigger = false;
		}
		//use emp
		if(Input.GetKeyDown("p")){
			if(!emp_trigger && emp_cd<=0) {
				emp_trigger = true;
				emp_cd = 30f; //emp cooldown timer
			}
		}
		if(emp_cd>=0) { //emp cd timer running
			emp_cd-=Time.deltaTime;
			if(emp_cd<=29f && emp_trigger) //emp duration end
				emp_trigger = false;
		}
		//use force field
		if(Input.GetKeyDown("l")){
			if(!forcefield_trigger && forcefield_cd<=0) {
				forcefield_trigger = true;
				Instantiate(ffield, new Vector3(0.03f, -0.5f, 0), Quaternion.identity);
				forcefield_cd = 8f; //forcefield cooldown timer
			}
		}
		if(forcefield_cd>=0) { //forcefield cd timer running
			forcefield_cd-=Time.deltaTime;
			if(forcefield_cd<=4f && forcefield_trigger) //forcefield duration end
				forcefield_trigger = false;
		}
		//End level trigger
		if(trigger) {
			if(wait_timer<3f)
				wait_timer+=Time.deltaTime;
			else
				Application.LoadLevel("GameScene");
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(30, 50, 80, 20), ((int)level_timer).ToString());
		if(frenzy_cd>0) {
			GUI.Label(new Rect(30, 90, 160, 20), "Frenzy cooldown: "+((int)frenzy_cd).ToString());
		}
		else{
			GUI.Label(new Rect(30, 90, 160, 20), "Frenzy ready");
		}
		if(emp_cd>0) {
			GUI.Label(new Rect(30, 130, 160, 20), "Emp cooldown: "+((int)emp_cd).ToString());
		}
		else {
			GUI.Label(new Rect(30, 130, 160, 20), "Emp ready");
		}
		if(forcefield_cd>0) {
			GUI.Label(new Rect(30, 170, 160, 20), "F-field cooldown: "+((int)forcefield_cd).ToString());
		}
		else {
			GUI.Label(new Rect(30, 170, 160, 20), "F-field ready");
		}
	}
}

