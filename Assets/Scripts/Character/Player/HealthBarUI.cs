using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthBarUI : MonoBehaviour
{
    private Character _character;
    private Image _healthBarImage;
    
	void Start ()
    {
        _character = GameObject.Find("Player").GetComponent<Character>();
        _healthBarImage = GetComponent<Image>();
	}
	
	void Update ()
    {
        if (!_healthBarImage)
            return;
        var mat = Instantiate(_healthBarImage.material);
        mat.SetFloat("_Health", _character? _character.Health : 0);
        mat.SetFloat("_MaxHealth", _character ? _character.MaxHealth : 1);
        _healthBarImage.material = mat;
    }
}
