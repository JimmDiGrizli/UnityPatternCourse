using Task_3.Scripts.VictoryPattern;
using TMPro;
using UnityEngine;
using Zenject;

namespace Task_3.Scripts.View
{
    public class RuleView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _ruleText;
        private IVictoryRuleProvider _ruleProvider;

        [Inject]
        private void Construct(IVictoryRuleProvider ruleProvider)
        {
            _ruleProvider = ruleProvider;
            Show();
        }

        public void Show()
        {
            if (_ruleProvider is null)
            {
                return;
            }
            gameObject.SetActive(true);
            _ruleText.SetText(_ruleProvider.CurrentRule());
        }

        public void Hide() => gameObject.SetActive(false);
    }
}