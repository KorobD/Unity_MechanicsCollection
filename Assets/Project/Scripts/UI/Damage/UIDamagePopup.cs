using TMPro;
using UnityEngine;



public class UIDamagePopup : MonoBehaviour {

    private TextMeshPro _textMeshPro;
    private float _disapperTimer;
    private Color _textColor;

    private void Awake() {

        _textMeshPro = transform.GetComponent<TextMeshPro>();

    }

    private void Update() {

        float moveYSpeed = 1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        _disapperTimer -= Time.deltaTime;
        if (_disapperTimer < 0) {
            float disappearSpeed = 3f;
            _textColor.a -= disappearSpeed * Time.deltaTime;
            _textMeshPro.color = _textColor;
            if (_textColor.a < 0) {
                Destroy(gameObject);
            }
        }

    }

    public static UIDamagePopup Create(Vector3 position, float damageAmount) {

        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        UIDamagePopup uIDamagePopup = damagePopupTransform.GetComponent<UIDamagePopup>();
        uIDamagePopup.Setup(damageAmount);
        return uIDamagePopup;

    }

    public void Setup(float damageAmount) {

        _textMeshPro.SetText(damageAmount.ToString());
        _disapperTimer = 1f;
        _textColor = _textMeshPro.color;
    }

}
