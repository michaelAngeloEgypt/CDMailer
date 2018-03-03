using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class MSG
    {
        public const string UnknownError = @"An unknown error occured, please check the logs";

        public const string GenerationSuccessful = "Successfully generated filled templates entries in the output folder";
        public const string FailedToGenerateOutput = @"Failed to generate messages. Please check the logs";
        public const string UnableToSaveConfig = @"An error occured while saving the configuration. Please check the logs";
        public const string InvalidFolderPath = @"Please input a valid folder.";
    }
}
