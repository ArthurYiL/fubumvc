﻿using FubuCore;

namespace FubuMVC.Core.View.Model
{
    public class MasterAttacher<T> 
    {

        private const string FallbackMaster = "Application";
        public string MasterName { get; set; }

        public MasterAttacher()
        {
            MasterName = FallbackMaster;
        }

        public bool CanAttach()
        {
//            var descriptor = request.Template;
//            var parsing =request.Template.Parsing;
//
//            return descriptor != null
//                   && descriptor.Master == null
//                   && (descriptor.ViewModel != null || parsing.Master.IsNotEmpty())
//                   && !request.Template.IsPartial()
//                   && parsing.Master != string.Empty
//                   && (!descriptor.Name().EqualsIgnoreCase(MasterName)
//                       ||
//                       (descriptor.Name().EqualsIgnoreCase(MasterName) && parsing.Master != null &&
//                        !parsing.Master.EqualsIgnoreCase(MasterName)));

            return true;
        }

//        public void Attach(IAttachRequest<T> request)
//        {
//            var template = request.Template;
//            var tracer = request.Logger;
//
//            var layoutName = template.Parsing.Master ?? MasterName;
//            var layout = _sharedTemplateLocator.LocateMaster(layoutName, template);
//
//            if (layout == null)
//            {
//                var notFound = "Expected master [{0}] not found.".ToFormat(layoutName);
//                tracer.Log(template, notFound);
//                return;
//            }
//
//            template.Master = layout;
//            var found = "Master [{0}] found at {1}".ToFormat(layoutName, layout.FilePath);
//            tracer.Log(template, found);
//        }
    }
}