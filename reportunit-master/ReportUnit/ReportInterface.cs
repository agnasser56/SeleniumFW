using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportUnit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using ReportUnit.Parser;
    using ReportUnit.Logging;

    public class ReportInterface
    {
        /// <summary>
        /// ReportUnit usage
        /// </summary>
        public ReportInterface()
        {
            
        }
        private static string USAGE = "[INFO] Usage 1:  ReportUnit \"path-to-folder\"" +
                                                "\n[INFO] Usage 2:  ReportUnit \"input-folder\" \"output-folder\"" +
                                                "\n[INFO] Usage 3:  ReportUnit \"input.xml\" \"output.html\"";

        /// <summary>
        /// Logger
        /// </summary>
        private static Logger _logger = Logger.GetLogger();

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Accepts 3 types of input arguments
        ///     Type 1: reportunit "path-to-folder"
        ///         args.length = 1 && args[0] is a directory
        ///     Type 2: reportunit "path-to-folder" "output-folder"
        ///         args.length = 2 && both args are directories
        ///     Type 3: reportunit "input.xml" "output.html"
        ///         args.length = 2 && args[0] is xml-input && args[1] is html-output
        public void GenerateReport(string sourceDirectory, string destinationDirectory)
        {
            try
            {
                if ((Path.GetExtension(sourceDirectory).ToLower().Contains("xml") || Path.GetExtension(sourceDirectory).ToLower().Contains("trx")) && (Path.GetExtension(sourceDirectory).ToLower().Contains("htm")))
                {
                    if (!Directory.GetParent(destinationDirectory).Exists)
                        Directory.CreateDirectory(Directory.GetParent(destinationDirectory).FullName);

                    new ReportUnitService().CreateReport(sourceDirectory, Directory.GetParent(destinationDirectory).FullName);
                    return;
                }
                if (!Directory.Exists(sourceDirectory))
                {
                    _logger.Error("Input directory " + sourceDirectory + " not found.");
                    return;
                }
                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(destinationDirectory);

                if (Directory.Exists(sourceDirectory) && Directory.Exists(destinationDirectory))
                {
                    new ReportUnitService().CreateReport(sourceDirectory, destinationDirectory);
                }
                else
                {
                    _logger.Error("Invalid files specified.\n" + USAGE);
                }
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
            }
    }
    }
}
