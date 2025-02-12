using UnityEngine;
using spaceExplorer.Player;

public class ParallaxLayer : MonoBehaviour {

	Vector3 wantedPosition;
	public float movement_resistance = 1f; //1 = no movement, 0.9 = some movement, 0.5 = more movement, etc, 0 = centered at origin, layer is now foreground
	// Update is called once per frame
	private void Update () {
		if(Player.Instance == null || !Application.isPlaying)
		{
            return;
        }
        wantedPosition = Player.Instance.transform.position * movement_resistance;
        wantedPosition.z = transform.position.z;
        transform.position = wantedPosition;
    }
}
