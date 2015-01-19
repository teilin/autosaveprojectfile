using EnvDTE;
using EnvDTE80;
using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisLindemark.AutoSave
{
    public class AutoSave : IDTExtensibility2
    {
        private AddIn _addInInstance;
        private DTE2 _applicationObject;
        private Events2 events;

        void ProjectItemsEvents_ItemRenamed(ProjectItem projectItem, string OldName)
        {
            Save(projectItem);
        }

        private void SolutionEvent(ProjectItem projectItem)
        {
            Save(projectItem);
        }

        void Save(ProjectItem projectItem)
        {
            if (!projectItem.ContainingProject.Saved)
                projectItem.ContainingProject.Save();
        }

        public void OnAddInsUpdate(ref Array custom)
        {
            //throw new NotImplementedException();
        }

        public void OnBeginShutdown(ref Array custom)
        {
            //throw new NotImplementedException();
        }

        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            //throw new NotImplementedException();
        }

        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            //throw new NotImplementedException();
        }

        public void OnStartupComplete(ref Array custom)
        {
            events = _applicationObject.Events as Events2;
            events.ProjectItemsEvents.ItemAdded += SolutionEvent;
            events.ProjectItemsEvents.ItemRemoved += SolutionEvent;
            events.ProjectItemsEvents.ItemRenamed +=
                new _dispProjectItemsEvents_ItemRenamedEventHandler(ProjectItemsEvents_ItemRenamed);
        }
    }
}
