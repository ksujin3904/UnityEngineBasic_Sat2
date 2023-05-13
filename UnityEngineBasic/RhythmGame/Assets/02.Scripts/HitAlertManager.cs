using RhythmGame.Assets._02.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RhythmGame
{
    public class HitAlertManager : MonoBehaviour
    {
        [SerializeField] private PopUpText _cool;
        [SerializeField] private PopUpText _great;
        [SerializeField] private PopUpText _good;
        [SerializeField] private PopUpText _miss;
        [SerializeField] private PopUpText _bad;
        [SerializeField] private PopUpText _combo;

        [SerializeField] NoteHitter[] _noteHitters;




        private void Awake()
        {
            for (int i = 0; i < _noteHitters.Length; i++)
            {
                _noteHitters[i].onHit += (value) =>
                {
                    if(value!=HitJudge.None)
                        PopUp(value);
                };
            }
            GameStatus.instance.onCurrentComboChanged += (value) =>
            {
                if (value > 1)
                    _combo.PopUp(value.ToString());
            };
        }

        public void PopUp(HitJudge judge)
        {
            if (_cool.gameObject.activeSelf) _cool.transform.Translate(Vector3.forward);
            if (_great.gameObject.activeSelf) _great.transform.Translate(Vector3.forward);
            if (_good.gameObject.activeSelf) _good.transform.Translate(Vector3.forward);
            if (_miss.gameObject.activeSelf) _miss.transform.Translate(Vector3.forward);
            if (_bad.gameObject.activeSelf) _bad.transform.Translate(Vector3.forward);

            switch (judge)
            {
                case HitJudge.None:
                    break;
                case HitJudge.Bad:
                    {
                        _bad.PopUp();
                        _bad.transform.Translate(Vector3.back);
                    }
                    break;
                case HitJudge.Miss:
                    {
                        _miss.PopUp();
                        _miss.transform.Translate(Vector3.back);
                    }
                    break;
                case HitJudge.Good:
                    {
                        _good.PopUp();
                        _good.transform.Translate(Vector3.back);
                    }
                    break;
                case HitJudge.Great:
                    {
                        _great.PopUp();
                        _great.transform.Translate(Vector3.back);
                    }
                    break;
                case HitJudge.Cool:
                    {
                        _cool.PopUp();
                        _cool.transform.Translate(Vector3.back);
                    }
                    break;
                default:
                    break;
            }



        }
    }
}
