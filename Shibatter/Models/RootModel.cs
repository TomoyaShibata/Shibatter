using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace Shibatter.Models
{
    class RootModel : BindableBase
    {
        private DraftListPageModel draftListPageModel = new DraftListPageModel();

        public DraftListPageModel DraftListPageModel
        {
            get { return this.draftListPageModel; }
            set { this.SetProperty(ref this.draftListPageModel, value); }
        }
    }
}
