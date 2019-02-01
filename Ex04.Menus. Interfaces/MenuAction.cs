using System;

namespace Ex04.Menus.Interfaces
{
    using System.Collections.Generic;

    public class MenuAction : MenuItem
    {
        private readonly List<IActionReporter> m_ActionReporters = new List<IActionReporter>();

        private readonly IAction r_Action;

        public MenuAction(IAction i_Action, string i_Title) : base(i_Title)
        {
            r_Action = i_Action;
        }

        public void AttachReporter(IActionReporter i_ActionReporter)
        {
            m_ActionReporters.Add(i_ActionReporter);
        }

        public void DetachReporter(IActionReporter i_ActionReporter)
        {
            m_ActionReporters.Remove(i_ActionReporter);
        }

        public override void Show()
        {
            Console.Clear();
            r_Action.DoAction();
        }

        private void notifyActionReporters()
        {
            foreach (IActionReporter reporter in m_ActionReporters)
            {
                reporter.ReportExecutingAction(r_Action);
            }
        }
    }
}