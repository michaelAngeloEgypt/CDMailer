using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    /// <summary>
    /// https://github.com/swxben/docx-template-engine
    /// </summary>
    class DocxTemplate
    {
        public static bool InsertTextInPlaceholders(string templatePath, string outputDocumentPath, Object obj)
        {
            try
            {
                if (!File.Exists(templatePath))
                    throw new FileNotFoundException();

                var templateEngine = new swxben.docxtemplateengine.DocXTemplateEngine();
                templateEngine.Process(templatePath, outputDocumentPath, obj);

                return true;
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                return false;
            }
        }

        /// <summary>
        /// https://github.com/swxben/docx-template-engine/issues/7
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ConvertLineBreaks(string input)
        {
            //return input.Replace(Environment.NewLine, "</w:t></w:r><w:r><w:br/><w:t>");
            //return input.Replace(Environment.NewLine, "<w:br/>");
            return input.Replace(Environment.NewLine, "</w:t><w:br/><w:t>");
        }

        public static string ConvertBullets(string input, string bulletString)
        {
            string output = input;
            if (output.Contains(bulletString))
            {
                //output = output.Replace("<w:t> �", "<w:t> •");
                output = output.Replace(bulletString, "•");
            }
            return output;
        }
    }
}
