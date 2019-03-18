using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualServersViewer.Models;

namespace VirtualServersViewer.ViewModels
{
    public class VirtualServersViewModel
    {
        public IList<VirtualServer> VirtualServerList { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime Timer { get; set; }
    }
}
