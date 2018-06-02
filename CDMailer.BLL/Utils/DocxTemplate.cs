using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    class DocxTemplate
    {
        public static bool InsertTextInPlaceholders(string templatePath, string outputDocumentPath, Object obj)
        {
            //return InsertTextInPlaceholders_sautinSoft(templatePath, outputDocumentPath, obj);
            return InsertTextInPlaceholders_swxben(templatePath, outputDocumentPath, obj);
        }

        /// <summary>
        /// <see cref="https://www.nuget.org/packages/sautinsoft.document/"/>
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="outputDocumentPath"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool InsertTextInPlaceholders_sautinSoft(string templatePath, string outputDocumentPath, Object obj)
        {
            try
            {
                if (!File.Exists(templatePath))
                    throw new FileNotFoundException();

                SautinSoft.Document.DocumentCore dc = SautinSoft.Document.DocumentCore.Load(templatePath);
                dc.MailMerge.Execute(obj);
                dc.Save(outputDocumentPath);

                return true;
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                return false;
            }
        }

        /// <summary>
        /// <see cref="https://github.com/swxben/docx-template-engine"/>
        /// </summary>
        public static bool InsertTextInPlaceholders_swxben(string templatePath, string outputDocumentPath, Object obj)
        {
            try
            {
                if (!File.Exists(templatePath))
                    throw new FileNotFoundException();

                PrepareObject(obj);
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


        private static void PrepareObject(Object obj)
        {
            Func<string, string> func1 = (x) => RemoveUnfreindlyMergeChars(x);
            obj.DoFunctionOnStringProperties(func1);
        }

        private static string RemoveUnfreindlyMergeChars(string source)
        {
            //var res = source.RemoveSpecialCharacters();       //--> removes space which we don't want
            var res = source.Replace("&nbsp;", " ").Trim();
            return res;
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
