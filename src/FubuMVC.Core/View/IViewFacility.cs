using System.Collections.Generic;
using FubuMVC.Core.Registration;
using FubuMVC.Core.View.Model;

namespace FubuMVC.Core.View
{
    /// <summary>
    /// Implement this contract to provide a service which allows to obatin
    /// <see cref="IViewToken"/>s based on a <see cref="TypePool"/> and the
    /// relevant <see cref="BehaviorGraph"/>
    /// </summary>
    public interface IViewFacility
    {
        void Fill(ViewEngineSettings settings, BehaviorGraph graph);
        IEnumerable<IViewToken> AllViews();

        ITemplateFile FindInShared(string viewName);
        ViewEngineSettings Settings { get; set; }
    }
}