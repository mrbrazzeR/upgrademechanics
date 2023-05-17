using TMPro;
using UnityEngine;

namespace Character
{
    public class CharacterView:MonoBehaviour
    {
        public CharacterInfo characterInfo;
        public TMP_Text hp;
        public TMP_Text damage;
        public TMP_Text def;

        public void SetData()
        {
            hp.text = characterInfo.hp.ToString();
            damage.text = characterInfo.damage.ToString();
            def.text = characterInfo.def.ToString();
        }
    }
}