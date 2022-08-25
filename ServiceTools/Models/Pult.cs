using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Models
{
    public class Pult
    {
        /// <summary>
        /// Серийный номер устройства.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Версия программы устройства.
        /// </summary>
        public string SoftwareVersion { get; set; }
    }
}
