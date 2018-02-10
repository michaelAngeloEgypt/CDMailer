using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class MSG
    {
        public const string UnknownError = @"An unknown error occured, please check the logs at c:\x\logs.txt";

        public const string GenerationSuccessful = "Successfully generated cleaned-up entries in the output folder";
        public const string FailedToGenerateOutput = @"Failed to generate tickets. Please check the log at c:\x\logs.txt";
        public const string ErrorWhileReadingInputs = @"An error occured while reading input files. Please check the log at c:\x\logs.txt";
        public const string UnableToSaveConfig = @"An error occured while saving the configuration. Please check the log at c:\x\logs.txt";
        public const string InvalidFolderPath = @"Please input a valid folder.";

        public const string IllegalGroupInOutputFile = "This file contains one or more combinations of (package,solution) that are not defined in the map";
        public const string BadOutputFile = "The associated output file does not follow the standards (see grid below), this update will be ignored.";
        public const string BadNumOfMilestones = "This output sheet uses a different set of milestones from those defined for its solution in the MAP, either in one or all of its groups";
        public const string NoMatchForPackageSolutionCustomerCountry = "No matching output sheet entries found containing the required (package, solution, customer, country) combination in the output sheet";
        public const string NoMatchForPackageSolutionCustomer = "No matching output sheet entries found containing the required (package, solution, customer) combination in the output sheet";


        public const string UnrecognisedInputFile = "This workbook is not in the list of standard workbooks defined in the Workbooks sheet in the MAP, it will be ignored.";
        public const string InvalidInputsFound = "One or more input mpp files does not follow the standards (see grid). These files were ignored.";
    }
}
