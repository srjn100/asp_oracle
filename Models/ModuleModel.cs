using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class ModuleModel
    {
        public string moduleCode { get; set; }
        public string moduleName { get; set; }
        public string syllabus { get; set; }
        public string mCode { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public MODULE getDAO()
        {
            return new MODULE { 
                MODULECODE = moduleCode,
                MODULENAME = moduleName,
                SYLLABUS = syllabus
            };
        }

        public static ModuleModel getViewModel(MODULE module)
        {
            return new ModuleModel { 
                moduleCode = module.MODULECODE,
                moduleName = module.MODULENAME,
                syllabus = module.SYLLABUS
            };
        }
    }
}